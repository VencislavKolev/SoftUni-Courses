using System;

namespace _04._Darts_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingPoints = int.Parse(Console.ReadLine());
            string sector = Console.ReadLine();
            int points = int.Parse(Console.ReadLine());
            int moves = 0;
            while (startingPoints >= 0)
            {
                moves++;
                if (sector == "number section")
                {
                    startingPoints -= points;
                }
                else if (sector == "double ring")
                {
                    startingPoints -= points * 2;
                }
                else if (sector == "triple ring")
                {
                    startingPoints -= points * 3;
                }
                if (startingPoints <= 0)
                {
                    break;
                }
                sector = Console.ReadLine();
                if (sector == "bullseye")
                {
                    moves++;
                    break;
                }
                points = int.Parse(Console.ReadLine());
            }
            if (sector == "bullseye")
            {
                Console.WriteLine($"Congratulations! You won the game with a bullseye in {moves} moves!");
            }
            else if (startingPoints==0)
            {
                Console.WriteLine($"Congratulations! You won the game in {moves} moves!");
            }
            else
            {
                Console.WriteLine($"Sorry, you lost. Score difference: {Math.Abs(startingPoints)}.");
            }
        }
    }
}
