using System;

namespace _02._Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double delay = Math.Floor(distanceInMeters / 50) * 30;
            double climbingTime = distanceInMeters * secondsPerMeter;
            double climbingTimeWithDelay = climbingTime + delay;

            if (climbingTimeWithDelay<recordInSeconds)
            {
                Console.WriteLine($"Yes! The new record is {climbingTimeWithDelay:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {Math.Abs(recordInSeconds-climbingTimeWithDelay):f2} seconds slower.");
            }
        }
    }
}
