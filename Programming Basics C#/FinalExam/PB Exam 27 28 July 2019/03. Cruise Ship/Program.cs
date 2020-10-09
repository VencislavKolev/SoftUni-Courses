using System;

namespace _03._Cruise_Ship
{
    class Program
    {
        static void Main(string[] args)
        {
            string cruise = Console.ReadLine();
            string room = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double price = 0;

            if (cruise == "Mediterranean")
            {
                if (room == "standard cabin")
                {
                    price = 27.50*nights*4;
                }
               else if (room == "cabin with balcony")
                {
                    price = 30.20 * nights * 4;
                }
               else if (room == "apartment")
                {
                    price = 40.50 * nights * 4;
                }
                if (nights > 7)
                {
                    price *= 0.75;
                }
            }
            else if (cruise == "Adriatic")
            {
                if (room == "standard cabin")
                {
                    price = 22.99 * nights * 4;
                }
                else if (room == "cabin with balcony")
                {
                    price = 25 * nights * 4;
                }
                else if (room == "apartment")
                {
                    price = 34.99 * nights * 4;
                }
                if (nights > 7)
                {
                    price *= 0.75;
                }
            }
            else if (cruise == "Aegean")
            {
                if (room == "standard cabin")
                {
                    price = 23 * nights * 4;
                }
                else if (room == "cabin with balcony")
                {
                    price = 26.6 * nights * 4;
                }
                else if (room == "apartment")
                {
                    price = 39.8 * nights * 4;
                }
                if (nights>7)
                {
                    price *= 0.75;
                }
            }
            Console.WriteLine($"Annie's holiday in the {cruise} sea costs {price:f2} lv.");
        }
    }
}
