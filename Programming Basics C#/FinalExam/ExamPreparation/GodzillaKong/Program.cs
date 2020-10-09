using System;

namespace GodzillaKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statist = int.Parse(Console.ReadLine());
            double clothingForOneStatist = double.Parse(Console.ReadLine());
            double decor = budget * 0.1;
            double AllClothing = statist * clothingForOneStatist;
            double totalExpenses = decor + AllClothing;
            double clothingAfterDiscount = AllClothing;

            if (statist>150)
            {
                clothingAfterDiscount = AllClothing * 0.9;
                totalExpenses = decor + clothingAfterDiscount;
            }


            if (budget<totalExpenses)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalExpenses-budget:f2} leva more.");
            }
            else if (budget>=totalExpenses)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget-totalExpenses:f2} leva left.");
            }
        }
    }
}
