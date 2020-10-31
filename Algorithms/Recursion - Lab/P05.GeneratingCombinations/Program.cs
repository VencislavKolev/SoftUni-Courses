using System;
using System.Linq;

namespace P05.GeneratingCombinations
{
    class Program
    {
        private static void GenerateCombination(int[] set, int[] vector, int index, int border)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }
            for (int i = border; i < set.Length; i++)
            {
                vector[index] = set[i];
                GenerateCombination(set, vector, index + 1, i + 1);
            }
        }
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int k = int.Parse(Console.ReadLine());
            int[] combArr = new int[k];

            GenerateCombination(arr, combArr, 0, 0);
        }
    }
}
