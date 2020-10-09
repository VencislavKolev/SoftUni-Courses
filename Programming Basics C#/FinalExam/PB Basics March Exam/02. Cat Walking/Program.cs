using System;

namespace _02._Cat_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesPerWalk = int.Parse(Console.ReadLine());
            int numberOfWalk = int.Parse(Console.ReadLine());
            int dailyCalories = int.Parse(Console.ReadLine());

            int burnedCaloriesPerWalk = minutesPerWalk * 5;
            int totalBurnedCalories = burnedCaloriesPerWalk * numberOfWalk;

            if (totalBurnedCalories >= dailyCalories / 2)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. " +
                    $"Burned calories per day: {totalBurnedCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. " +
                    $"Burned calories per day: {totalBurnedCalories}.");
            }
        }
    }
}
