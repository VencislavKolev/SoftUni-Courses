using System;

namespace _02._Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int graphicCards = int.Parse(Console.ReadLine());
            int CPU= int.Parse(Console.ReadLine());
            int RAM = int.Parse(Console.ReadLine());

            double graphicCardsPrice = graphicCards * 250;
            double cpuPrice = graphicCardsPrice*0.35*CPU;
            double ramPrice = graphicCardsPrice*0.10*RAM;
            double totalCost = graphicCardsPrice+cpuPrice+ramPrice;

            if (graphicCards>CPU)
            {
                totalCost *= 0.85;
            }
            if (totalCost<=budget)
            {
                Console.WriteLine($"You have {budget-totalCost:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalCost-budget:f2} leva more!");
            }
        }
    }
}
