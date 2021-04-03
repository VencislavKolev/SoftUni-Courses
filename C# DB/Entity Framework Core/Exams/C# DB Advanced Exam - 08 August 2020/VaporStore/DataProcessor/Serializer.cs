namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            //JSON EXPORT

            var exportedGames = context.Genres
                .ToArray()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                        .Select(g => new
                        {
                            Id = g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = string.Join(", ", g.GameTags.Select(t => t.Tag.Name)),
                            Players = g.Purchases.Count()
                        })
                        .Where(g => g.Players > 0)
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id)
                        .ToArray(),
                    TotalPlayers = x.Games.Sum(x => x.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToArray();

            string json = JsonConvert.SerializeObject(exportedGames, Formatting.Indented);

            return json;

        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            ////XML EXPORT

            //ExportUserPurchaseDto[] userPurchases = context.Users
            //    .ToArray()
            //    .Where(x => x.Cards.
            //        Any(c => c.Purchases
            //            .Any(p => p.Type.ToString() == storeType)))
            //    .Select(x => new ExportUserPurchaseDto
            //    {
            //        UserName = x.Username,
            //        Purchases = x.Cards.SelectMany(c => c.Purchases)
            //            .Where(p => p.Type.ToString() == storeType)
            //            .Select(p => new ExportPurchaseDto
            //            {
            //                CardNumber = p.Card.Number,
            //                CVC = p.Card.Cvc,
            //                Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
            //                Game = new ExportGameDto
            //                {
            //                    Title = p.Game.Name,
            //                    Genre = p.Game.Genre.Name,
            //                    Price = p.Game.Price
            //                }
            //            })
            //            .OrderBy(x => x.Date)
            //            .ToArray(),
            //        TotalSpent = x.Cards.Sum(x => x.Purchases
            //            .Where(x => x.Type.ToString() == storeType)
            //                .Sum(x => x.Game.Price))
            //    })
            //    .OrderByDescending(x => x.TotalSpent)
            //    .ThenBy(x => x.UserName)
            //    .ToArray();

            //string xml = XmlConverter.Serialize<ExportUserPurchaseDto[]>(userPurchases, "Users");

            //return xml;

            var data = context.Users.ToList()
                .Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(x => new ExportUserPurchaseDto
                {
                    UserName = x.Username,
                    TotalSpent = x.Cards.Sum(
                        c => c.Purchases.Where(p => p.Type.ToString() == storeType)
                              .Sum(p => p.Game.Price)),
                    Purchases = x.Cards.SelectMany(c => c.Purchases)
                        .Where(p => p.Type.ToString() == storeType)
                        .Select(p => new ExportPurchaseDto
                        {
                            CardNumber = p.Card.Number,
                            CVC = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto
                            {
                                Title = p.Game.Name,
                                Price = p.Game.Price,
                                Genre = p.Game.Genre.Name,
                            }
                        })
                        .OrderBy(x => x.Date)
                        .ToArray()
                })
                .OrderByDescending(x => x.TotalSpent).ThenBy(x => x.UserName).ToArray();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportUserPurchaseDto[]),
                    new XmlRootAttribute("Users"));
            var sw = new StringWriter();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(sw, data, ns);
            return sw.ToString();
        }
    }
}