using System;
using System.Linq;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                long[] numbers = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                long maxNum = Math.Max(numbers[0], numbers[1]);
                long currSumOfDigits = 0;
                while (Math.Abs(maxNum) > 0)
                {
                    currSumOfDigits += maxNum % 10;
                    maxNum /= 10;
                }
                Console.WriteLine(Math.Abs(currSumOfDigits));
            }
        }
    }
}
//using System;

//namespace _02._From_Left_to_The_Right
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int numberOfInputLines = int.Parse(Console.ReadLine());
//            for (int i = 0; i < numberOfInputLines; i++)
//            {
//                string twoNumbers = Console.ReadLine();
//                string[] separatedNumbers = twoNumbers.Split(' ');
//                long num1 = long.Parse(separatedNumbers[0]);
//                long num2 = long.Parse(separatedNumbers[1]);
//                long biggestNum = Math.Max(num1, num2);
//                long sumOfDigits = 0;
//                while (Math.Abs(biggestNum) != 0)
//                {
//                    sumOfDigits += biggestNum % 10;
//                    biggestNum /= 10;
//                }
//                Console.WriteLine(Math.Abs(sumOfDigits));
//            }
//        }
//    }
//}
