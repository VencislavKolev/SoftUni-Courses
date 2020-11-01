
using P04.PizzaCalories.Common;
using System;
using System.Linq;
using System.Reflection;

namespace P04.PizzaCalories.Models
{
    public class Topping
    {
        private const double BASE_TOPPING_CALORIES = 2;
        private const double MEAT_CALORIES = 1.2;
        private const double VEGGIES_CALORIES = 0.8;
        private const double CHEESE_CALORIES = 1.1;
        private const double SAUCE_CALORIES = 0.9;

        private string toppingType;
        private double weight;
        private readonly string[] validToppings = new string[]
        {
            "meat","veggies","cheese","sauce"
        };
        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get { return this.toppingType; }
            private set
            {
                string topping = value.ToLower();
                if (!this.validToppings.Contains(topping))
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidToppingMessage, value));
                }
                this.toppingType = value;
            }
        }
        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidToppingWeightMessage, this.ToppingType));
                }
                this.weight = value;
            }
        }
        public double Calories
        {
            get { return this.CalculateToppingCalories(); }
        }
        private double CalculateToppingCalories()
        {
            double toppingModifier = 0;
            switch (this.ToppingType.ToLower())
            {
                case "meat": toppingModifier = MEAT_CALORIES; break;
                case "veggies": toppingModifier = VEGGIES_CALORIES; break;
                case "cheese": toppingModifier = CHEESE_CALORIES; break;
                case "sauce": toppingModifier = SAUCE_CALORIES; break;
            }
            return BASE_TOPPING_CALORIES * this.Weight * toppingModifier;
        }
    }
}
