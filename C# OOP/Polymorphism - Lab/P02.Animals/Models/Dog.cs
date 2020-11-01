using System;

namespace Animals.Models
{
    public class Dog : Animal
    {
        private const string DOG_SOUND = "DJAAF";

        public Dog(string name, string favFood)
            : base(name, favFood)
        {

        }
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + DOG_SOUND;
        }
    }
}
