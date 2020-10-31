using System;

namespace P03.RecursiveDrawing
{
    class Program
    {
        static void PrintFigure(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(new string('*', n));
            PrintFigure(n - 1);
            Console.WriteLine(new string('#', n));
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintFigure(n);
        }
    }
}
