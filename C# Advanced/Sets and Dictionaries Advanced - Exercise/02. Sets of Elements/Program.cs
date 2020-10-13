using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            int[] countOfLines = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = countOfLines[0];
            int m = countOfLines[1];
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }
            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }
            //IEnumerable<int> intersect = firstSet.Intersect(secondSet);
            Console.WriteLine(string.Join(" ", firstSet.Intersect(secondSet)));
        }
    }
}
