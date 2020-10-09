using System;

namespace _05._Divide_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p1Count = 0;
            int p2Count = 0;
            int p3Count = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0) // проверка дали остатъка при деление на 2 е 0,т.е деление на 2 без остатък
                {
                    p1Count++;
                }
                if (number % 3 == 0) // проверка дали остатъка при деление на 3 е 0,т.е деление на 3 без остатък
                {
                    p2Count++;
                }
                if (number % 4 == 0) // проверка дали остатъка при деление на 4 е 0,т.е деление на 4 без остатък
                {
                    p3Count++;
                }
            }
            Console.WriteLine($"{p1Count * 1.0 / n * 100:f2}%");
            Console.WriteLine($"{p2Count * 1.0 / n * 100:f2}%");
            Console.WriteLine($"{p3Count * 1.0 / n * 100:f2}%");
        }
    }
}
