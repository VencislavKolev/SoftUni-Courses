using System;

namespace DailyEarnings
{
    class Program
    {
        static void Main(string[] args)
        {
            int workDaysInMonth = int.Parse(Console.ReadLine());
            double money1day = double.Parse(Console.ReadLine());
            double usd2bgnRate = double.Parse(Console.ReadLine());

            double monthlySalary = workDaysInMonth * money1day;
            double bonus = 2.5 * monthlySalary;
            double GrossYearlySalary = 12 * monthlySalary + bonus;
            double deduction = GrossYearlySalary * 0.25;
            double NetYearlySalary = GrossYearlySalary - deduction;
            double netIncomeForDay = NetYearlySalary / 365;

            Console.WriteLine(Math.Round(netIncomeForDay*usd2bgnRate,2));

        }
    }
}
