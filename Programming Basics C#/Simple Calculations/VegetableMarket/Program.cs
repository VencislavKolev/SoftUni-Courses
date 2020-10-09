using System;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double lvKgVeg = double.Parse(Console.ReadLine());
            double lvKgFruit = double.Parse(Console.ReadLine());
            int kgVeg = int.Parse(Console.ReadLine());
            int kgFruit = int.Parse(Console.ReadLine());

            double income = ((lvKgFruit * kgFruit) + (lvKgVeg * kgVeg))/1.94;
            //double incomeEuro = income / 1.94;
            Console.WriteLine($"{income}");
        }
    }
}
