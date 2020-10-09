using System;

namespace ExamToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double TripPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double EarnedMoneyBeforeDiscount = 2.6 * puzzles + 3 * dolls +
                4.1 * bears + 8.2 * minions + 2 * trucks;
            int totalCount = puzzles + dolls + bears + minions + trucks;

            double MoneyAfterFirstDiscount = EarnedMoneyBeforeDiscount;
            if (totalCount >= 50)
            {
                MoneyAfterFirstDiscount = EarnedMoneyBeforeDiscount * 0.75;
            }
            double MoneyAfterRent = MoneyAfterFirstDiscount * 0.9;
            
            if (MoneyAfterRent >= TripPrice)
            {
                Console.WriteLine($"Yes! {MoneyAfterRent - TripPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {TripPrice-MoneyAfterRent:f2} lv needed.");
            }
        }
    }
}
