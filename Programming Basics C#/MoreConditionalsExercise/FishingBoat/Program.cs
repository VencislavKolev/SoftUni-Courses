using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherman= int.Parse(Console.ReadLine());
            double rentPriceForBoat = 0;
            switch (season)
            {
                case "Spring":rentPriceForBoat = 3000;break;
                case "Summer":rentPriceForBoat = 4200;break;
                case "Autumn":rentPriceForBoat = 4200;break;
                case "Winter":rentPriceForBoat = 2600;break;
                
            }
            if (fisherman<=6)
            {
                rentPriceForBoat *= 0.9;
            }
            else if (fisherman>6 && fisherman<=11)
            {
                rentPriceForBoat *= 0.85;
            }
            else if (fisherman > 11)
            {
                rentPriceForBoat *= 0.75;
            }
            

            if (fisherman %2==0 && season!="Autumn")
            {
                rentPriceForBoat *= 0.95;
            }
            bool isEnough = budget >= rentPriceForBoat;
            if (isEnough)
            {
                Console.WriteLine($"Yes! You have {budget-rentPriceForBoat:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {rentPriceForBoat-budget:f2} leva.");
            }
        }
    }
}
