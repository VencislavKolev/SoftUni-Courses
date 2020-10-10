using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double waterDayPerson = double.Parse(Console.ReadLine());
            double foodDayPerson = double.Parse(Console.ReadLine());

            double totalWater = days * players * waterDayPerson;
            double totalFood = days * players * foodDayPerson;
            bool isEnough = true;
            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                energy -= energyLoss;
                if (energy <= 0)
                {
                    isEnough = false;
                    break;
                }
                if (i % 2 == 0)
                {
                    energy *= 1.05;
                    totalWater *= 0.7;
                }
                if (i % 3 == 0)
                {
                    totalFood -= totalFood / players;
                    energy *= 1.1;
                }
            }
            if (isEnough)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
            }
        }
    }
}
