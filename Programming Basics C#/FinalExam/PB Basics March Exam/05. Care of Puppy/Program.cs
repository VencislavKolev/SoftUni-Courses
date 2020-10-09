using System;

namespace _05._Care_of_Puppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantityKilos = int.Parse(Console.ReadLine());
            int foodQuantityGrams = foodQuantityKilos * 1000;
            string command = Console.ReadLine();
            int totalGramsBeforeAdopted = 0;
            while (command != "Adopted")
            {
                int gramsPerMeal = int.Parse(command);
                totalGramsBeforeAdopted += gramsPerMeal;
                command = Console.ReadLine();
            }

            if (totalGramsBeforeAdopted <= foodQuantityGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodQuantityGrams - totalGramsBeforeAdopted} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(totalGramsBeforeAdopted - foodQuantityGrams)} grams more.");
            }
        }
    }
}
