using System;

namespace _02._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            ClosestPointToCenter(x1, y1, x2, y2);
        }
        static void ClosestPointToCenter(double x1, double y1, double x2, double y2)
        {
            double bestX, bestY;
            if (Math.Abs(x1) + Math.Abs(y1) <= Math.Abs(x2) + Math.Abs(y2))
            {
                bestX = x1;
                bestY = y1;
            }
            else
            {
                bestX = x2;
                bestY = y2;
            }
            Console.WriteLine($"({bestX}, {bestY})");
        }
    }
}
