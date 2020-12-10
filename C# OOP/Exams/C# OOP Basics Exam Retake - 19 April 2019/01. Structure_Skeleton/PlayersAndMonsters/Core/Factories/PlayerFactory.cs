
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {

            IPlayer player = null;
            ICardRepository cardRepository = new CardRepository();
            switch (type.ToLower())
            {
                case "beginner":
                    player = new Beginner(cardRepository, username);
                    break;
                case "advanced":
                    player = new Advanced(cardRepository, username);
                    break;
            }
            return player;
        }
    }
}
