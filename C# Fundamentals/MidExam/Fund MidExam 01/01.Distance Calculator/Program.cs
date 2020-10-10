using System;

namespace _01.Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double stepLengthInCantimeters = double.Parse(Console.ReadLine());
            int totalDistance = int.Parse(Console.ReadLine());
            //5th step 30% shorter
            //работим в САНТИМЕТРИ
            double shorterFifthStepLength = stepLengthInCantimeters * 0.7;
            int shorterStepsMade = stepsMade / 5;
            double shorterStepDistance = shorterStepsMade * shorterFifthStepLength;
            double normalStepsDistance = (stepsMade - shorterStepsMade) * stepLengthInCantimeters;
            double travelledDistance = normalStepsDistance + shorterStepDistance;
            double percentage = travelledDistance / totalDistance;

            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");
        }
    }
}
