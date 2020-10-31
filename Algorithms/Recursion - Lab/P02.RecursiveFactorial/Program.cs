using System;

namespace P02.RecursiveFactorial
{
    class Program
    {
        static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            long result = n * Factorial(n - 1);
            return result;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long factorialResult = Factorial(n);
            Console.WriteLine(factorialResult);
        }
    }
}
