using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] digits = Console.ReadLine().TrimStart('0').ToCharArray();
            int multiplier = int.Parse(Console.ReadLine());
            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }
            StringBuilder sb = new StringBuilder();
            //  string finalResult = "";
            int remaining = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int currDigit = int.Parse(digits[i].ToString());
                int result = currDigit * multiplier + remaining;
                int ones = result % 10;
                remaining = result / 10;
                //   finalResult += ones;
                sb.Append(ones);
            }
            if (remaining != 0)
            {
                //finalResult += remaining;
                sb.Append(remaining);
            }
            char[] finalReversed = sb.ToString().Reverse().ToArray();
            //for (int i = finalResult.Length - 1; i >= 0; i--)
            //{
            //    finalReversed += finalResult[i];
            //}
            Console.WriteLine(string.Join("", finalReversed));
        }
    }
}
