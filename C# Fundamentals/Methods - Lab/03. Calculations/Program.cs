using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            switch (action)
            {
                case "add": SumTwoNumbers(num1, num2); break;
                case "multiply": MultiplyTwoNumbers(num1, num2); break;
                case "substract": SubstractTwoNumbers(num1, num2); break;
                case "divide": DivideTwoNumbers(num1, num2); break;
            }
        }
        static void SumTwoNumbers(int first, int second)
        {
            int sum = first + second;
            Console.WriteLine(sum);
            //Console.WriteLine(first+second);
        }
        static void DivideTwoNumbers(int purvo, int vtoro)
        {
            Console.WriteLine(purvo / vtoro);
            //int division = purvo / vtoro;
            //Console.WriteLine(division);
        }
        static void MultiplyTwoNumbers(int first, int second)
        {
            int multiplication = first * second;
            Console.WriteLine(multiplication);
        }
        static void SubstractTwoNumbers(int first, int second)
        {
            int substraction = first - second;
            Console.WriteLine(substraction);
        }
    }
}
