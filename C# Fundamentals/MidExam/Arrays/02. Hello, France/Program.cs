using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split('|').ToArray();
            double budget = double.Parse(Console.ReadLine());
            int moneyGoal = 150;
            double profit = 0;
            double updatedPriceSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                string[] splitted = arr[i].Split("->").ToArray();
                string type = splitted[0];
                double price = double.Parse(splitted[1]);
                if (((type == "Clothes" && price <= 50) ||
                    (type == "Shoes" && price <= 35) ||
                    (type == "Accessories" && price <= 20.50))
                    && price <= budget)
                {
                    budget -= price;
                    double updatedPrice = price * 1.4;
                    updatedPriceSum += updatedPrice;
                    Console.Write($"{updatedPrice:f2}" + " ");
                    profit += price * 1.4 - price;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:f2}");
            double finalBduget = updatedPriceSum + budget;
            if (finalBduget >= moneyGoal)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
