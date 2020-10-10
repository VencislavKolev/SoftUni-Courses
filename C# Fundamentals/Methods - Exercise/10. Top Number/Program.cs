using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                int currNum = i;
                if (IsDivisibleByEight(currNum) && HasAtleastOneOddDigit(currNum))
                {
                    Console.WriteLine(currNum);
                }
            }
        }
        static bool HasAtleastOneOddDigit(int num)
        {
            int oddDigitCount = 0;
            while (num > 0)
            {
                int rem = num % 10;
                num /= 10;
                if (rem % 2 != 0)
                {
                    oddDigitCount++;
                }
            }
            return oddDigitCount >= 1;
        }
        static bool IsDivisibleByEight(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            if (sum % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
