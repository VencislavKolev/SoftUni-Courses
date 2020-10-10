using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int currentNum = i;
                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum /= 10;
                }
                bool isSpecial = false;
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    isSpecial = true;
                }
                Console.WriteLine("{0} -> {1}", i, isSpecial);
            }
        }
    }
}
