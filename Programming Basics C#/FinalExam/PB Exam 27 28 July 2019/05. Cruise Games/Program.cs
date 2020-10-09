using System;

namespace _05._Cruise_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            int gamesPlayed = int.Parse(Console.ReadLine());
            double averageScoreV = 0;
            double averageScoreT = 0;
            double averageScoreB = 0;
            double totalScoreV = 0;
            double totalScoreT = 0;
            double totalScoreB = 0;
            int vCount = 0;
            int bCount = 0;
            int tCount = 0;
            for (int i = 0; i < gamesPlayed; i++)
            {
                string game = Console.ReadLine();
                int points = int.Parse(Console.ReadLine());
                if (game == "volleyball")
                {
                    vCount++;
                    totalScoreV += points * 1.07;
                    averageScoreV = Math.Floor(totalScoreV / vCount);
                }
                else if (game == "tennis")
                {
                    tCount++;
                    totalScoreT += points * 1.05;
                    averageScoreT = Math.Floor(totalScoreT / tCount);
                }
                else if (game == "badminton")
                {
                    bCount++;
                    totalScoreB += points * 1.02;
                    averageScoreB = Math.Floor(totalScoreB / bCount);
                }
            }
            double totalScore = totalScoreB + totalScoreT + totalScoreV;
            if (averageScoreB >= 75 && averageScoreV >= 75 && averageScoreT >= 75)
            {
                Console.WriteLine($"Congratulations, {playerName}! You won the cruise games with {Math.Floor(totalScore)} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {playerName}, you lost. Your points are only {Math.Floor(totalScore)}.");
            }
        }
    }
}
