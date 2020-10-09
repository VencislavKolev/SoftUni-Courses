using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minuteExam = int.Parse(Console.ReadLine());
            int hourArrival = int.Parse(Console.ReadLine());
            int minuteArrival = int.Parse(Console.ReadLine());

            int diffHours = 0;
            int diffMinutesOT = minuteExam - minuteArrival;
            int diffMinutesEarly = minuteExam - minuteArrival;
            int diffMinutesLate = minuteArrival -minuteExam;
            string status = "";

            bool isEarly = (hourArrival <= hourExam);
            if (isEarly)
            {
                status = "Early";
                diffHours = hourExam - hourArrival;
                if (minuteExam < minuteArrival)
                {
                    diffMinutesEarly += 60;
                    diffHours -= 1;
                }
                if (diffHours <= 1 && (diffMinutesEarly > 30 && diffMinutesEarly < 60))
                {
                    Console.WriteLine(status);
                    Console.WriteLine($"{diffMinutesEarly} minutes before the start");
                }
                else if (diffHours >= 1 && diffMinutesEarly >= 0)
                {
                    Console.WriteLine(status);
                    Console.WriteLine($"{diffHours}:{diffMinutesEarly:d2} hours before the start");
                }
            }
            bool isOnTime = (hourArrival <= hourExam && diffMinutesOT <= 30);
            if (isOnTime)
            {
                status = "On time";
                if (minuteExam < minuteArrival)
                {
                    diffMinutesOT += 60;
                }
                if ((diffMinutesOT > 0 && diffMinutesOT <= 30) && diffHours <= 1)
                {
                    Console.WriteLine(status);
                    Console.WriteLine($"{diffMinutesOT} minutes before the start");
                }
                else if (hourExam == hourArrival && minuteArrival == minuteExam)
                {
                    Console.WriteLine(status);
                }
            }
            bool isLate = (hourArrival >= hourExam);
            if (isLate)
            {
                status = "Late";
                diffHours = hourArrival - hourExam;
                if (minuteExam>minuteArrival)
                {
                    diffMinutesLate = minuteArrival + minuteExam;
                    diffHours -= 1;
                }
                if (diffHours == 0 && (diffMinutesLate < 60))
                {
                    Console.WriteLine(status);
                    Console.WriteLine($"{diffMinutesLate} minutes after the start");
                }
                else if (diffHours >= 1 && diffMinutesLate >= 0)
                {
                    Console.WriteLine(status);
                    Console.WriteLine($"{diffHours}:{diffMinutesLate:d2} hours after the start");
                }
            }
        }
    }
}
