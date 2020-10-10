using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            int givenNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length; i++)
            {
                int currNum = arr[i];
                for (int index = i + 1; index < arr.Length; index++)
                {
                    if (currNum + arr[index] == givenNumber)
                    {
                        Console.WriteLine(currNum + " " + arr[index]);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
