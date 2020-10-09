using System;

namespace _06._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            for (int i = 1; i <= first; i++)
            {
                if (i % 2 != 0)
                {
                    continue;
                }
                for (int j = 2; j <= second; j++)
                {
                    bool isPrime = true;
                    for (int x = 2; x <= Math.Sqrt(j); x++)
                    {
                        if (j % x == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        for (int k = 1; k <= third; k++)
                        {
                            if (k % 2 != 0)
                            {
                                continue;
                            }
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
