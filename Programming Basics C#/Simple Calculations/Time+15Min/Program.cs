using System;

namespace Time_15Min
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes += 15;

            if (minutes>=60)
            {
                minutes -= 60;
                hour += 1;
            }
            if (hour>=24)
            {
                hour -= 24;
            }
            Console.WriteLine($"{hour}:{minutes:d2}");
        }
    }
}
