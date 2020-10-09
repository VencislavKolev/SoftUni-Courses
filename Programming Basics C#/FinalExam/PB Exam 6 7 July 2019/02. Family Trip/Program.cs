using System;

namespace _02._Family_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double pricePerNight= double.Parse(Console.ReadLine());
            int addExpenses = int.Parse(Console.ReadLine());
            double priceForAllNights = 0;
            double totalExpenses = 0;
            if (nights>7)
            {
                pricePerNight *= 0.95;
                priceForAllNights = pricePerNight * nights;
            }
            else
            {
                priceForAllNights = pricePerNight * nights;
            }
            totalExpenses = priceForAllNights + (addExpenses * budget) / 100 ;
            if (totalExpenses<=budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget-totalExpenses:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{totalExpenses-budget:f2} leva needed.");
            }
        }
    }
}
