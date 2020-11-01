
using P04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;

namespace P04.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double WEIGHT_MULTIPLIER = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override ICollection<Type> PrefferedFoods => new List<Type> { typeof(Meat), typeof(Vegetable), typeof(Seeds), typeof(Fruit) };

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
