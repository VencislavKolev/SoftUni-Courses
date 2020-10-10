using System;

namespace _03._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());
            ClosestPointToCenter(x1, y1, x2, y2,
                                x3, y3, x4, y4);
        }
        static void ClosestPointToCenter
            (double x1, double y1, double x2, double y2,
             double x3, double y3, double x4, double y4)
        {
            double bestX1, bestY1;
            double bestX2, bestY2;
            if ((Math.Abs(x1) + Math.Abs(y1) + Math.Abs(x2) + Math.Abs(y2))
                >=
                Math.Abs(x3) + Math.Abs(y3) + Math.Abs(x4) + Math.Abs(y4))
            {
                if ((Math.Abs(x1) + Math.Abs(y1) <= Math.Abs(x2) + Math.Abs(y2)))
                {
                    bestX1 = x1;
                    bestY1 = y1;
                    bestX2 = x2;
                    bestY2 = y2;
                }
                else
                {
                    bestX1 = x2;
                    bestY1 = y2;
                    bestX2 = x1;
                    bestY2 = y1;
                }
            }
            else
            {
                if ((Math.Abs(x3) + Math.Abs(y3) <= Math.Abs(x4) + Math.Abs(y4)))
                {
                    bestX1 = x3;
                    bestY1 = y3;
                    bestX2 = x4;
                    bestY2 = y4;
                }
                else
                {
                    bestX1 = x4;
                    bestY1 = y4;
                    bestX2 = x3;
                    bestY2 = y3;
                }
            }
            Console.WriteLine($"({bestX1}, {bestY1})({bestX2}, {bestY2})");
        }
    }
}
