using System;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int leftRacerTime = 0;
            int rightRacerTime = 0;
            int[] timePerStep = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int finishLineIndex = timePerStep.Length / 2;

            for (int i = 0; i < finishLineIndex; i++)
            {
                int currStepTime = timePerStep[i];
                leftRacerTime = ProcessCurrentStep(leftRacerTime, currStepTime);
            }
            for (int i = timePerStep.Length - 1; i > finishLineIndex; i--)
            {
                int currStepTime = timePerStep[i];
                rightRacerTime = ProcessCurrentStep(rightRacerTime, currStepTime);
            }

            int winningTime = rightRacerTime;
            /*Math.Min(leftRacerTime, rightRacerTime);*/
            string winner = "right";
            if (leftRacerTime < rightRacerTime)
            {
                winner = "left";
                winningTime = leftRacerTime;
            }
            Console.WriteLine($"The winner is {winner} with total time: {winningTime}");
        }

        private static int ProcessCurrentStep(int currRacerTime, int currStepTime)
        {
            if (currStepTime == 0)
            {
                currRacerTime *= 0.8;
            }
            else
            {
                currRacerTime += currStepTime;
            }

            return currRacerTime;
        }
    }
}
