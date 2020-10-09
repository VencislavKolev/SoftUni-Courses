using System;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysGone = int.Parse(Console.ReadLine());
            int LeftFoodInKG = int.Parse(Console.ReadLine());
            double Dog1DayKG = double.Parse(Console.ReadLine());
            double Cat1DayKG = double.Parse(Console.ReadLine());
            double Turtle1DayGrams = double.Parse(Console.ReadLine());

            double Turtle1DayKG = Turtle1DayGrams / 1000;
            double FoodNeeded = daysGone * (Dog1DayKG + Cat1DayKG + Turtle1DayKG);
            double FoodLeft = LeftFoodInKG - FoodNeeded;
            if (FoodNeeded<=LeftFoodInKG)
            {
                Console.WriteLine($"{Math.Floor(FoodLeft)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(FoodNeeded-LeftFoodInKG)} more kilos of food are needed.");
            }
        }
    }
}
