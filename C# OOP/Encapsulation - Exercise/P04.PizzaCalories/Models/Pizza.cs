using P04.PizzaCalories.Common;
using P04.PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace P04.PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        private Pizza()
        {
            this.toppings = new List<Topping>();
        }
        public Pizza(string name)
            : this()
        {
            this.Name = name;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException(GlobalConstants.InvalidPizzaNameMessage);
                }
                this.name = value;
            }
        }
        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }
        public int ToppingsCount
        {
            get { return this.toppings.Count; }
        }
        public double TotalCalories()
        {
            //totalPizzaCalories += this.dough.Calories;
            //foreach (var topping in this.toppings)
            //{
            //    totalPizzaCalories += topping.Calories;
            //}
            double totalPizzaCalories = this.Dough.Calories + this.toppings.Sum(t => t.Calories);
            return totalPizzaCalories;
        }
        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException(GlobalConstants.InvalidNumberOfToppingsMessage);
            }
            this.toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories():f2} Calories.";
        }
    }
}
