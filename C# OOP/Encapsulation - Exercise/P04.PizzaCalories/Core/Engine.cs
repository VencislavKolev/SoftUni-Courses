using P04.PizzaCalories.Models;
using System;
using System.Linq;

namespace P04.PizzaCalories.Core
{
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            try
            {
                string[] pizzaTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string pizzaName = string.Empty;
                if (pizzaTokens.Length >= 2)
                {
                    pizzaName = pizzaTokens[1];
                }
                Pizza pizza = new Pizza(pizzaName);

                string[] doughTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string flourType = doughTokens[1];
                string bakingTechnique = doughTokens[2];
                double doughWeight = double.Parse(doughTokens[3]);
                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                pizza.Dough = dough;

                string[] toppingArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                while (toppingArgs[0] != "END")
                {
                    string toppingType = toppingArgs[1];
                    double toppingWeight = double.Parse(toppingArgs[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    toppingArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }
                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
