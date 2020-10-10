using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            double remainingBalance = currentBalance;
            string command = Console.ReadLine();
            double gamePrice = 0;
            while (command != "Game Time")
            {
                switch (command)
                {
                    case "OutFall 4": gamePrice = 39.99; break;
                    case "CS: OG": gamePrice = 15.99; break;
                    case "Zplinter Zell": gamePrice = 19.99; break;
                    case "Honored 2": gamePrice = 59.99; break;
                    case "RoverWatch": gamePrice = 29.99; break;
                    case "RoverWatch Origins Edition": gamePrice = 39.99; break;

                    default:
                        Console.WriteLine("Not Found");
                        command = Console.ReadLine(); continue;
                }
                if (remainingBalance == 0)
                {
                    break;
                }
                else if (gamePrice > remainingBalance)
                {
                    Console.WriteLine("Too Expensive");
                }
                else if (gamePrice <= remainingBalance)
                {
                    remainingBalance -= gamePrice;
                    Console.WriteLine($"Bought {command}");
                }
                command = Console.ReadLine();
            }
            double moneySpentOnGames = Math.Abs(remainingBalance - currentBalance);
            if (remainingBalance == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${moneySpentOnGames:f2}. Remaining: ${remainingBalance:f2}");
            }
        }
    }
}
