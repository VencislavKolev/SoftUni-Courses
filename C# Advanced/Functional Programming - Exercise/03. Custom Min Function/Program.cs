using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = (arr) =>
            {
                int minValue = int.MaxValue;
                foreach (var num in arr)
                {
                    if (num < minValue)
                    {
                        minValue = num;
                    }
                }
                return minValue;
            };

            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minNumber(arr));

        }
    }
}
