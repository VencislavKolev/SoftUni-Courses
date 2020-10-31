using System;
using System.Linq;

namespace P01.RecursiveArraySum
{
    class Program
    {
        static int CalculateSum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }
            int sum = arr[index] + CalculateSum(arr, index + 1);
            return sum;
        }
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int result = CalculateSum(arr, 0);
            Console.WriteLine(result);
        }
    }
}
