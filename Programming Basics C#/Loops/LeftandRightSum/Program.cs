using System;

namespace LeftandRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 1; i <= numbers; i++)
            {
                int currentNumber1 = int.Parse(Console.ReadLine());
                sum1 += currentNumber1;
            }
            for (int j = 1; j <= numbers; j++)
            {
                int currentNumber2 = int.Parse(Console.ReadLine());
                sum2 += currentNumber2;
            }
            if (sum1==sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else if (sum1 != sum2)
            {
                Console.WriteLine($"No, diff = {Math.Abs(sum1-sum2)}");
            }
        }
    }
}
