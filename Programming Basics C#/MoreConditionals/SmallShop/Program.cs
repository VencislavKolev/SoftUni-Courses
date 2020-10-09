using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Продукт: ");
            string product = Console.ReadLine();
            Console.Write("Град: ");
            string city = Console.ReadLine();
            Console.Write("Количество: ");
            double quantity = double.Parse(Console.ReadLine());

            if (city == "Sofia")
            {
                switch (product)
                {
                    case "coffee": Console.WriteLine(quantity * 0.50); break;
                    case "water": Console.WriteLine(quantity * 0.80); break;
                    case "beer": Console.WriteLine(quantity * 1.20); break;
                    case "sweets": Console.WriteLine(quantity * 1.45); break;
                    case "peanuts": Console.WriteLine(quantity * 1.60); break;
                    default:
                        break;
                }
            }
            else if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee": Console.WriteLine(quantity * 0.40); break;
                    case "water": Console.WriteLine(quantity * 0.70); break;
                    case "beer": Console.WriteLine(quantity * 1.15); break;
                    case "sweets": Console.WriteLine(quantity * 1.30); break;
                    case "peanuts": Console.WriteLine(quantity * 1.50); break;
                    default:
                        break;
                }
            }
            else if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee": Console.WriteLine(quantity * 0.45); break;
                    case "water": Console.WriteLine(quantity * 0.70); break;
                    case "beer": Console.WriteLine(quantity * 1.10); break;
                    case "sweets": Console.WriteLine(quantity * 1.35); break;
                    case "peanuts": Console.WriteLine(quantity * 1.55); break;
                    default:
                        break;
                }
            }
        }
    }
}
