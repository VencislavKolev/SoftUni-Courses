using System;

namespace _01._Pool_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double entryTax = double.Parse(Console.ReadLine());
            double deckchairPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double totalEntryTax = people * entryTax;
            double deckchair = Math.Ceiling(people * 0.75)*deckchairPrice;
            double umbrella = Math.Ceiling(people*1.0/2)*umbrellaPrice;
            double finalSum = totalEntryTax + deckchair + umbrella;
            Console.WriteLine($"{finalSum:f2} lv.");

        }
    }
}
