using System;

namespace ShivashkiCeh
{
    class Program
    {
        static void Main(string[] args)
        {
            double tables = double.Parse(Console.ReadLine());
            double lenghtRectTable = double.Parse(Console.ReadLine());
            double widthRectTable = double.Parse(Console.ReadLine());

            double spaceRect = tables * (lenghtRectTable + 2 * 0.3) * (widthRectTable + 2 * 0.3);
            double spaceSquare = tables * (lenghtRectTable / 2) * (lenghtRectTable / 2);

            double TotalUsd = spaceRect * 7+spaceSquare*9;
            double TotalBgn = TotalUsd * 1.85;
           

            Console.WriteLine($"{TotalUsd:f2} USD");
            Console.WriteLine($"{TotalBgn:f2} BGN");


        }
    }
}
