using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForTrip = double.Parse(Console.ReadLine());
            double balance = double.Parse(Console.ReadLine());
            int spendCounter = 0;
            int days = 0;
            while (balance < moneyForTrip)
            {
                string action = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                days++;

                if (action == "save")
                {
                    spendCounter = 0;
                    balance += money;
                }
                else if (action == "spend")
                {
                    spendCounter++;
                    balance -= money;
                    if (balance < 0)
                    {
                        balance = 0;
                    }
                }

                if (spendCounter == 5)
                {
                    break;
                }
            }
            if (balance >= moneyForTrip)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
            if (spendCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            }

        }
    }
}
