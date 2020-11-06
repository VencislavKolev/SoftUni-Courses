﻿
namespace _1.Prototype
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            string ingredients = this.GetIngredients();
            System.Console.WriteLine($"Cloning sandiwich with ingredients: {ingredients}.");

            return MemberwiseClone() as SandwichPrototype;
        }
        private string GetIngredients()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
