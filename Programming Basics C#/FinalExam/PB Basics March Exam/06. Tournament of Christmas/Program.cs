using System;

namespace _06._Tournament_of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int daysWon = 0;
            int daysLost = 0;
            int dailyWinCounter = 0;
            int dailyLosesCounter = 0;
            double dailyMoneyWon = 0;
            double totalMoneyWon = 0;

            for (int i = 1; i <= days; i++)
            {
                dailyWinCounter = 0;
                dailyLosesCounter = 0;
                string sport = Console.ReadLine();
                while (sport != "Finish")
                {
                    string result = Console.ReadLine();
                    if (result == "win")
                    {
                        dailyWinCounter++;
                        dailyMoneyWon += 20;
                    }
                    else if (result == "lose")
                    {
                        dailyLosesCounter++;
                    }
                    sport = Console.ReadLine();
                }
                if (dailyWinCounter > dailyLosesCounter)
                {
                    dailyMoneyWon *= 1.1;
                    daysWon++;
                }
                else
                {
                    daysLost++;
                }
                totalMoneyWon += dailyMoneyWon;
                dailyMoneyWon = 0;
            }
            if (daysWon > daysLost)
            {
                totalMoneyWon *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoneyWon:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoneyWon:f2}");
            }

        }
    }
}
