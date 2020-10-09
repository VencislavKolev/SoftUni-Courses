using System;

namespace _04._Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double wantedIncome = double.Parse(Console.ReadLine());
            string cocktail = Console.ReadLine();
            double cocktailPrice = 0;
            double totalSum = 0;
            while (cocktail != "Party!")
            {
                int quantity = int.Parse(Console.ReadLine());
                cocktailPrice = cocktail.Length * quantity;
                if (cocktailPrice % 2 != 0)
                {
                    cocktailPrice *= 0.75;
                }

                totalSum += cocktailPrice;
                if (totalSum >= wantedIncome)
                {
                    Console.WriteLine("Target acquired.");
                    break;
                }
                cocktail = Console.ReadLine();

            }
            if (cocktail == "Party!")
            {
                Console.WriteLine($"We need {wantedIncome - totalSum:f2} leva more.");
            }
            Console.WriteLine($"Club income - {totalSum:f2} leva.");
        }
    }
}
