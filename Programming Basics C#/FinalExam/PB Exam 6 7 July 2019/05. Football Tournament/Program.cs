using System;

namespace _05._Football_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int playedMatches = int.Parse(Console.ReadLine());
            int wCount = 0;
            int dCount = 0;
            int lCount = 0;
            int pointsWon = 0;
            for (int i = 0; i < playedMatches; i++)
            {
                char result = char.Parse(Console.ReadLine());
                switch (result)
                {
                    case 'W':wCount++;pointsWon += 3; break;
                    case 'D':dCount++; pointsWon += 1; break;    
                    case 'L':lCount++;break;
                }
            }
            if (playedMatches==0)
            {
                Console.WriteLine($"{teamName} hasn't played any games during this season.");
            }
            else
            {
                Console.WriteLine($"{teamName} has won {pointsWon} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {wCount}");
                Console.WriteLine($"## D: {dCount}");
                Console.WriteLine($"## L: {lCount}");
                Console.WriteLine($"Win rate: {wCount*1.0/playedMatches*100:f2}%");
            }
        }
    }
}
