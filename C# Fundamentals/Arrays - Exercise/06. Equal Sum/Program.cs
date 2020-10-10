using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().
                Select(int.Parse).ToArray();
            bool isFound = false;
            for (int currentIndex = 0; currentIndex < arr.Length; currentIndex++)
            {
                int rightSum = 0;
                for (int i = currentIndex + 1; i < arr.Length; i++)
                {
                    rightSum += arr[i];
                }
                int leftSum = 0;
                for (int i = currentIndex - 1; i >= 0; i--)
                {
                    leftSum += arr[i];
                }
                if (rightSum == leftSum)
                {
                    Console.WriteLine(currentIndex);
                    isFound = true;
                }
            }
            if (isFound == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
