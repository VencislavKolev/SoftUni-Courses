using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double RecordSec = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeFor1meter = double.Parse(Console.ReadLine());
            double ResistanceTime = Math.Floor(distance / 15)*12.5;
            double totalTimeIvan = distance * timeFor1meter+ResistanceTime;

            if (totalTimeIvan<RecordSec)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTimeIvan:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {totalTimeIvan-RecordSec:f2} seconds slower.");
            }
        }
    }
}
