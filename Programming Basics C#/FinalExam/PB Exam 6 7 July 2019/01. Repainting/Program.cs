using System;

namespace _01._Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylonQuantity = int.Parse(Console.ReadLine());
            int paintQuantity = int.Parse(Console.ReadLine());
            int paintThinnerQuantity = int.Parse(Console.ReadLine());
            int workingHours = int.Parse(Console.ReadLine());

            double nylonPrice = 1.50*(nylonQuantity+2);
            double paint = 14.50*paintQuantity*1.10;
            double paintThinner = 5.00*paintThinnerQuantity;
            double total = nylonPrice + paint + paintThinner + 0.4;
            double salaryWorkers = total * 0.3*workingHours;
            double totalExpenses = total + salaryWorkers;
            Console.WriteLine($"Total expenses: {totalExpenses:f2} lv.");

        }
    }
}
