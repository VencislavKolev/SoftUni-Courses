using System;

namespace _04._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p1Count = 0;
            int p2Count = 0;
            int p3Count = 0;
            int p4Count = 0;
            int p5Count = 0;

            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                if (numbers < 200)
                {
                    p1Count++;
                }
                else if (numbers < 400)
                {
                    p2Count++;
                }
                else if (numbers < 600)
                {
                    p3Count++;
                }
                else if (numbers < 800)
                {
                    p4Count++;
                }
                else if (numbers >= 800)
                {
                    p5Count++;
                }

            }
            Console.WriteLine($"{p1Count * 1.0 / n * 100:f2}%");
            Console.WriteLine($"{p2Count * 1.0 / n * 100:f2}%");
            Console.WriteLine($"{p3Count * 1.0 / n * 100:f2}%");
            Console.WriteLine($"{p4Count * 1.0 / n * 100:f2}%");
            Console.WriteLine($"{p5Count * 1.0 / n * 100:f2}%");
        }
    }
}
