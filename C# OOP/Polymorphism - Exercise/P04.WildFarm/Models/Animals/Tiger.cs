
using P04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;

namespace P04.WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double WEIGHT_MULTIPLIER = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override ICollection<Type> PrefferedFoods => new List<Type> { typeof(Meat) };

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
