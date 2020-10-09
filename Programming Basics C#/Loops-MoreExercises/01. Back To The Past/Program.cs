using System;

namespace _01._Back_To_The_Past
{
    class Program
    {
        static void Main(string[] args)
        {
            double nasledeniPari = double.Parse(Console.ReadLine());
            int lastYearOfLife = int.Parse(Console.ReadLine());
            double spentMoneyEvenYear = 0;
            double spentMoneyOddYear = 0;
            double moneyLeft = 0;
            int currentAge = 18;
            int currentYear = 1800;

            for (int i = 1800; i <= lastYearOfLife; i++)
            {
                if (currentYear % 2 == 0)
                {
                    spentMoneyEvenYear += 12000;
                    currentYear++;
                    currentAge++;
                }
                else
                {
                    spentMoneyOddYear += 12000 + 50 * currentAge;
                    currentAge++;
                    currentYear++;
                }
            }
            moneyLeft = nasledeniPari - (spentMoneyEvenYear + spentMoneyOddYear);
            if (moneyLeft >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeft:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(moneyLeft):f2} dollars to survive.");
            }

        }
    }
}
