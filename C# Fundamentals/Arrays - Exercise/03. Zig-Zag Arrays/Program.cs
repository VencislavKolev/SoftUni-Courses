using System;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[] arr1 = new string[rows];
            string[] arr2 = new string[rows];
            for (int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (i % 2 == 0)
                {
                    arr2[i] += input[1];
                    arr1[i] += input[0];
                }
                else
                {
                    arr1[i] += input[1];
                    arr2[i] += input[0];
                }
            }
            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
