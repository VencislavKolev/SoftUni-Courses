
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;
            switch (type.ToLower())
            {
                case "trap":
                    card = new TrapCard(name);
                    break;
                case "magic":
                    card = new MagicCard(name);
                    break;
            }
            return card;
        }
    }
}
