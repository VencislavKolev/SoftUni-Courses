using System;

namespace _03._Coffee_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;
            if (drink == "Espresso")
            {
                switch (sugar)
                {
                    case "Without": price = 0.90 * quantity; break;
                    case "Normal": price = 1 * quantity; break;
                    case "Extra": price = 1.20 * quantity; break;
                }
            }
            else if (drink == "Cappuccino")
            {
                switch (sugar)
                {
                    case "Without": price = 1 * quantity; break;
                    case "Normal": price = 1.20 * quantity; break;
                    case "Extra": price = 1.60 * quantity; break;
                }
            }
            else if (drink == "Tea")
            {
                switch (sugar)
                {
                    case "Without": price = 0.50 * quantity; break;
                    case "Normal": price = 0.60 * quantity; break;
                    case "Extra": price = 0.70 * quantity; break;
                }
            }
            if (sugar=="Without")
            {
                price *= 0.65;
            }
            if (drink=="Espresso" && quantity>=5)
            {
                price *= 0.75;
            }
            if (price>15)
            {
                price *= 0.80;
            }
            Console.WriteLine($"You bought {quantity} cups of {drink} for {price:f2} lv.");
        }
    }
}
