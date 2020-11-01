
using P03.Raiding.Models.Contracts;

namespace P03.Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }

        public abstract int Power { get; }


        public abstract string CastAbility();
    }
}
