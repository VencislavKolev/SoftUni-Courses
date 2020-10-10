using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            double num2 = double.Parse(Console.ReadLine());

            double result = Calculate(num1, @operator, num2);
            Console.WriteLine(result);
        }
        static double Calculate(double a, string @operator, double b)
        {
            double result = 0;
            switch (@operator)
            {
                case "+": result = a + b; break;
                case "-": result = a - b; break;
                case "*": result = a * b; break;
                case "/": result = a / b; break;
            }
            return result;
        }
    }
}
