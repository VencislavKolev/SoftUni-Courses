using System;

namespace _04._Food_for_Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalFoodQuantity = double.Parse(Console.ReadLine());

            double totalDogFood = 0;
            double totalCatFood = 0;
            double biscuits = 0;

            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                int dogFood = int.Parse(Console.ReadLine());
                int catFood = int.Parse(Console.ReadLine());
                totalDogFood += dogFood;
                totalCatFood += catFood;

                if (currentDay % 3 == 0)
                {
                    biscuits += (dogFood + catFood) * 0.1;
                }
            }
            double totalEatenFood = totalDogFood + totalCatFood;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{(totalEatenFood / totalFoodQuantity) * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{(totalDogFood / totalEatenFood) * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{(totalCatFood / totalEatenFood) * 100:f2}% eaten from the cat.");
        }
    }
}
