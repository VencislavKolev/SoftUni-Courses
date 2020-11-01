
using P03.Raiding.Models;
using P03.Raiding.Models.Contracts;

namespace P03.Raiding.Factories
{
   public class HeroFactory
    {
        public IBaseHero ProduceHero(string type,string name)
        {
            IBaseHero hero = null;
            if (type=="Druid")
            {
                hero = new Druid(name);
            }
           else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            return hero;
        }
    }
}
