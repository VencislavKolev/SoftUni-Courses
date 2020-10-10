using System;

namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double fuelKmPrice = double.Parse(Console.ReadLine());
            double dailyFoodExpenses = double.Parse(Console.ReadLine());
            double oneNightHotelPrice = double.Parse(Console.ReadLine());

            bool isEnough = true;
            double foodExpenses = days * people * dailyFoodExpenses;
            double hotelExpenses = people * days * oneNightHotelPrice;
            if (people > 10)
            {
                hotelExpenses *= 0.75;
            }
            double currExpenses = foodExpenses + hotelExpenses;
            for (int i = 1; i <= days; i++)
            {
                double dailyFuelExpenses = 0;
                double travelledDailyDistanceKM = double.Parse(Console.ReadLine());
                dailyFuelExpenses = travelledDailyDistanceKM * fuelKmPrice;
                currExpenses += dailyFuelExpenses;
                if (i % 3 == 0 || i % 5 == 0)
                {
                    currExpenses *= 1.4;
                }
                if (i % 7 == 0)
                {
                    currExpenses -= currExpenses / people * 1.0;
                }
                if (currExpenses > budget)
                {
                    isEnough = false;
                    break;
                }
            }
            if (isEnough)
            {
                Console.WriteLine($"You have reached the destination. You have {budget - currExpenses:f2}$ budget left.");
            }
            else
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {currExpenses - budget:f2}$ more.");
            }
        }
    }
}
