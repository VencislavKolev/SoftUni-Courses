using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double finalPriceApartment = 0;
            double finalPriceStudio = 0;

            if (month == "May" || month == "October")
            {
                finalPriceStudio = 50 * nights;
                finalPriceApartment = 65 * nights;
                if (nights > 7 && nights <= 14)
                {
                    finalPriceStudio *= 0.95;
                }
                else if (nights > 14)
                {
                    finalPriceStudio *= 0.7;
                    finalPriceApartment *= 0.9;
                }
            }
            else if (month == "June" || month == "September")
            {
                finalPriceStudio = 75.2 * nights;
                finalPriceApartment = 68.7 * nights;
                if (nights > 14)
                {
                    finalPriceStudio *= 0.80;
                    finalPriceApartment *= 0.90;
                }
            }
            else if (month == "July" || month == "August")
            {
                finalPriceStudio = 76 * nights;
                finalPriceApartment = 77 * nights;
                if (nights > 14)
                {
                    finalPriceApartment *= 0.90;
                }
            }
            Console.WriteLine($"Apartment: {finalPriceApartment:f2} lv.");
            Console.WriteLine($"Studio: {finalPriceStudio:f2} lv.");
        }
    }
}

