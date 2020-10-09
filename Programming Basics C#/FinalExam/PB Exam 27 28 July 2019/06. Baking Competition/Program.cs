using System;

namespace _06._Baking_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int competitors = int.Parse(Console.ReadLine());
            int cookiesCount = 0;
            int cakesCount = 0;
            int wafflesCount = 0;
            int bakedSweets = 0;
            double totalBaked = 0;
            double totalMoney = 0;

            for (int i = 1; i <= competitors; i++)
            {
                string name = Console.ReadLine();
                string sweetType = Console.ReadLine();
                while (sweetType != "Stop baking!")
                {
                    bakedSweets = int.Parse(Console.ReadLine());
                    switch (sweetType)
                    {
                        case "cookies": cookiesCount += bakedSweets; break;
                        case "cakes": cakesCount += bakedSweets; break;
                        case "waffles": wafflesCount += bakedSweets; break;
                    }
                    sweetType = Console.ReadLine();
                }
                totalBaked += cookiesCount + cakesCount + wafflesCount;
                totalMoney += cookiesCount * 1.5 + cakesCount * 7.8 + wafflesCount * 2.3;

                Console.WriteLine($"{name} baked {cookiesCount} cookies, {cakesCount} cakes and {wafflesCount} waffles.");
                cookiesCount = 0;
                cakesCount = 0;
                wafflesCount = 0;
            }
            Console.WriteLine($"All bakery sold: {totalBaked}");
            Console.WriteLine($"Total sum for charity: {totalMoney:f2} lv.");
        }
    }
}
