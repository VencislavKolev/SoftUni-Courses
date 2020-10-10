using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double factorialOfNum1 = CalculateFactorial(num1);
            double factorialOfNum2 = CalculateFactorial(num2);
            double output = factorialOfNum1 / factorialOfNum2;
            Console.WriteLine($"{output:f2}");

        }
        static double CalculateFactorial(double number)
        {
            double factorial = 1;
            for (double currNum = number; currNum >= 1; currNum--)
            {
                factorial *= currNum;
            }
            return factorial;
        }
    }
}
