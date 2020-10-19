using System;
using System.IO;

namespace Action_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Actions is applicable to void methods
            ProcessResult(Console.WriteLine);
            ProcessResult(num => Console.WriteLine(num * 2));
            ProcessResult(num => File.WriteAllText("Result.txt", num.ToString()));

            Action<int, int> action = MultyplyTwoNumbers;
            action(10, 5);
        }
        static void MultyplyTwoNumbers(int x, int y)
        {
            Console.WriteLine($"Multiplication result from {x} * {y} is:");
            Console.WriteLine(x * y);
        }
        static void ProcessResult(Action<int> myAction)
        {
            int result = 212;
            myAction(result);
        }
    }
}
