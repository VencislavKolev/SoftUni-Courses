namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        private const string ERROR_MESSAGE = "Invalid Data";
        private const string SUCCESSFULL_GAME_IMPORT = "Added {0} ({1}) with {2} tags";
        private const string SUCCESSFULL_USER_CARDS_IMPORT = "Imported {0} with {1} cards";
        private const string SUCCESSFULL_PURCHASE_IMPORT = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportGameDto[] gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            List<Game> games = new List<Game>();

            foreach (var jsonGame in gamesDto)
            {
                if (!IsValid(jsonGame) || jsonGame.Tags.Count() == 0)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                Genre genre = context.Genres
                    .FirstOrDefault(x => x.Name == jsonGame.Genre)
                    ?? new Genre { Name = jsonGame.Genre };

                Developer developer = context.Developers
                    .FirstOrDefault(x => x.Name == jsonGame.Developer)
                    ?? new Developer { Name = jsonGame.Developer };

                Game game = new Game
                {
                    Name = jsonGame.Name,
                    Genre = genre,
                    Developer = developer,
                    Price = jsonGame.Price,
                    ReleaseDate = jsonGame.ReleaseDate.Value
                };

                foreach (var jsonTag in jsonGame.Tags)
                {
                    Tag tag = context.Tags
                        .FirstOrDefault(x => x.Name == jsonTag)
                        ?? new Tag { Name = jsonTag };

                    game.GameTags.Add(new GameTag { Tag = tag });
                }
                context.Games.Add(game);
                context.SaveChanges();

                sb.AppendLine(string.Format(SUCCESSFULL_GAME_IMPORT,
                    game.Name,
                    game.Genre.Name,
                    game.GameTags.Count));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportUserDto[] usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            foreach (var userJson in usersDto)
            {
                if (!IsValid(userJson) || !userJson.Cards.All(IsValid))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                //if (userJson.Cards.Any(x => !IsValid(x)))
                //{
                //    sb.AppendLine(ERROR_MESSAGE);
                //    continue;
                //}

                User user = new User
                {
                    FullName = userJson.FullName,
                    Username = userJson.Username,
                    Age = userJson.Age,
                    Email = userJson.Email,
                    Cards = userJson.Cards
                        .Select(c => new Card
                        {
                            Number = c.Number,
                            Cvc = c.CVC,
                            Type = c.Type.Value
                        }).ToList()
                };

                context.Users.Add(user);
                context.SaveChanges();

                sb.AppendLine(string.Format(SUCCESSFULL_USER_CARDS_IMPORT,
                    user.Username,
                    user.Cards.Count));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPurchaseDto[] purchasesDto = XmlConverter.Deserializer<ImportPurchaseDto>(xmlString, "Purchases");

            List<Purchase> purchases = new List<Purchase>();

            foreach (var pDto in purchasesDto)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                DateTime date;
                bool isValidDate = DateTime.TryParseExact(pDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isValidDate)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                Game game = context.Games.FirstOrDefault(x => x.Name == pDto.Title);
                if (game == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                Card card = context.Cards.FirstOrDefault(x => x.Number == pDto.Card);
                if (card == null)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                Purchase purchase = new Purchase
                {
                    Type = pDto.Type.Value,
                    ProductKey = pDto.Key,
                    Date = date,
                    Card = card,
                    Game = game
                };
                purchases.Add(purchase);

                sb.AppendLine(string.Format(SUCCESSFULL_PURCHASE_IMPORT,
                    game.Name,
                    card.User.Username));
            }
            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}