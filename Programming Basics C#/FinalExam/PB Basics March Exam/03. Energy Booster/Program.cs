using System;

namespace _03._Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int orders = int.Parse(Console.ReadLine());

            double totalSum = 0;

            if (size == "small")
            {
                switch (fruit)
                {
                    case "Watermelon": totalSum = 2 * 56 * orders; break;
                    case "Mango": totalSum = 2 * 36.66 * orders; break;
                    case "Pineapple": totalSum = 2 * 42.10 * orders; break;
                    case "Raspberry": totalSum = 2 * 20 * orders; break;
                }
            }
            else if (size == "big")
            {
                switch (fruit)
                {
                    case "Watermelon": totalSum = 5 * 28.7 * orders; break;
                    case "Mango": totalSum = 5 * 19.6 * orders; break;
                    case "Pineapple": totalSum = 5 * 24.80 * orders; break;
                    case "Raspberry": totalSum = 5 * 15.20 * orders; break;
                }
            }
            if (totalSum >= 400 && totalSum <= 1000)
            {
                totalSum *= 0.85;
            }
            else if (totalSum > 1000)
            {
                totalSum *= 0.5;
            }
            Console.WriteLine($"{totalSum:f2} lv.");
        }
    }
}
