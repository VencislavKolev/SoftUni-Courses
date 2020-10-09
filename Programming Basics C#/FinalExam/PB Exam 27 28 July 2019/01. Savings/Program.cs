using System;

namespace _01._Savings
{
    class Program
    {
        static void Main(string[] args)
        {
            double salary = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double billsPerMonth = double.Parse(Console.ReadLine());

            double ownExpenses = salary * 0.3;
            double savings = salary - (billsPerMonth + ownExpenses);
            double savingsPercentage = savings / salary;
            Console.WriteLine($"She can save {savingsPercentage * 100:f2}%");
            Console.WriteLine($"{savings * months:f2}");
        }
    }
}
