using System;

namespace Conditionals_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int sec1 = int.Parse(Console.ReadLine());
            int sec2 = int.Parse(Console.ReadLine());
            int sec3 = int.Parse(Console.ReadLine());

            int totalSeconds = sec1 + sec2 + sec3;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            Console.WriteLine($"{minutes}:{seconds:d2}");
        }
    }
}
