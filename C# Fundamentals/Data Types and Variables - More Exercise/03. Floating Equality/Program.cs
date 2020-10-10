using System;

namespace _03._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            double bigger = Math.Max(numberA, numberB);
            double smaller = Math.Min(numberA, numberB);
            bool isEqual = (bigger - smaller < eps);
            if (isEqual)
            {
                Console.WriteLine(isEqual);
            }
            else
            {
                isEqual = false;
                Console.WriteLine(isEqual);
            }
        }
    }
}
