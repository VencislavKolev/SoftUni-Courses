﻿
using P04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;

namespace P04.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double WEIGHT_MULTIPLIER = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override ICollection<Type> PrefferedFoods => new List<Type> { typeof(Meat) };

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
