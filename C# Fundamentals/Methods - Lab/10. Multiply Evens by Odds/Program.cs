using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int result = GetMultipleOfEvenAndOdds(number);
            Console.WriteLine(result);
        }
        static int GetMultipleOfEvenAndOdds(int num)
        {
            int evenSum = GetEvenSumOfDigits(num);
            int oddSum = GetOddSumOfDigits(num);
            return evenSum * oddSum;
        }
        static int GetEvenSumOfDigits(int num)
        {
            int sumEven = 0;
            while (num > 0)
            {
                int currDigit = num % 10;
                if (currDigit % 2 == 0)
                {
                    sumEven += currDigit;
                }
                num /= 10;
            }
            return sumEven;
        }
        static int GetOddSumOfDigits(int num)
        {
            int sumOdd = 0;
            while (num > 0)
            {
                int currDigit = num % 10;
                if (currDigit % 2 != 0)
                {
                    sumOdd += currDigit;
                }
                num /= 10;
            }
            return sumOdd;
        }
    }
}
