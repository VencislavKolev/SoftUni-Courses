using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static List<int> ReadIntListSingleLine()
        {
            List<int> list = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            return list;
        }
        static void Main(string[] args)
        {
            var firstList = ReadIntListSingleLine();
            var secondList = ReadIntListSingleLine();

            Console.WriteLine(string.Join(" ", MergedList(firstList, secondList)));

        }
        static List<int> MergedList(List<int> first, List<int> second)
        {
            int bestCount = Math.Max(first.Count, second.Count);
            List<int> merged = new List<int>();
            for (int i = 0; i < bestCount; i++)
            {
                if (i < first.Count)
                {
                    merged.Add(first[i]);
                }
                if (i < second.Count)
                {
                    merged.Add(second[i]);
                }
            }
            return merged;
        }
    }
}
