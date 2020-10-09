using System;

namespace SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int DaysOff = int.Parse(Console.ReadLine());
            int workingDaysPlayTime = (365 - DaysOff)*63;
            int playTimeDaysOff = DaysOff * 127;
            int totalMinutesForPlay = workingDaysPlayTime + playTimeDaysOff;

            int ExtraTime = Math.Abs (totalMinutesForPlay - 30000);
            int hours = ExtraTime / 60;
            int minutes = ExtraTime % 60;
            if (minutes >= 60)
            {
                minutes -= 60;
            }
            if (totalMinutesForPlay>30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }

        }
    }
}
