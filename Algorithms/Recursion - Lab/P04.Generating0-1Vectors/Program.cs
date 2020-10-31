using System;

namespace P04.Generating0_1Vectors
{
    class Program
    {
        static void GenerateVector(int[] arr, int index)
        {
            if (index > arr.Length - 1)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }
            for (int i = 0; i <= 1; i++)
            {
                arr[index] = i;
                GenerateVector(arr, index + 1);
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            GenerateVector(arr, 0);
        }
    }
}
