using System;

namespace _03._Fitness_Card
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            char sex = Convert.ToChar(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double membershipPrice = 0;

            if (sex == 'm')
            {
                switch (sport)
                {
                    case "Gym": membershipPrice = 42; break;
                    case "Boxing": membershipPrice = 41; break;
                    case "Yoga": membershipPrice = 45; break;
                    case "Zumba": membershipPrice = 34; break;
                    case "Dances": membershipPrice = 51; break;
                    case "Pilates": membershipPrice = 39; break;

                }
            }
            else if (sex == 'f')
            {
                switch (sport)
                {
                    case "Gym": membershipPrice = 35; break;
                    case "Boxing": membershipPrice = 37; break;
                    case "Yoga": membershipPrice = 42; break;
                    case "Zumba": membershipPrice = 31; break;
                    case "Dances": membershipPrice = 53; break;
                    case "Pilates": membershipPrice = 37; break;
                }
            }
            if (age <= 19)
            {
                membershipPrice *= 0.8;
            }
            if (sum >= membershipPrice)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${membershipPrice - sum:f2} more.");
            }
        }
    }
}
