using System;

namespace Odd_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddNum = 0;
            double oddSum = 0;
            double minOdd = int.MaxValue;
            double maxOdd = int.MinValue;

            double EvenNum = 0;
            double evenSum = 0;
            double minEven = int.MaxValue;
            double maxEven = int.MinValue;


            for (int i = 1; i <= n; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    oddNum = currentNumber;
                    oddSum += currentNumber;
                    if (currentNumber < minOdd)
                    {
                        minOdd = currentNumber;
                    }
                    if (currentNumber > maxOdd)
                    {
                        maxOdd = currentNumber;
                    }
                }
                else
                {
                    EvenNum = currentNumber;
                    evenSum += currentNumber;

                    if (currentNumber < minEven)
                    {
                        minEven = currentNumber;
                    }
                    if (currentNumber > maxEven)
                    {
                        maxEven = currentNumber;
                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine($"OddSum={oddSum:f2},");
            if (minOdd != int.MaxValue)
            {
                Console.WriteLine($"OddMin={ minOdd:f2},");
            }
            else
            {
                Console.WriteLine($"OddMin=No,");
            }
            if (maxOdd != int.MinValue)
            {
                Console.WriteLine($"OddMax={ maxOdd:f2},");
            }
            else
            {
                Console.WriteLine($"OddMax=No,");
            }

            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (minEven != int.MaxValue)
            {
                Console.WriteLine($"EvenMin={ minEven:f2},");
            }
            else
            {
                Console.WriteLine($"EvenMin=No,");
            }
            if (maxEven != int.MinValue)
            {
                Console.WriteLine($"EvenMax={ maxEven:f2}");
            }
            else
            {
                Console.WriteLine($"EvenMax=No");
            }
        }
    }
}
