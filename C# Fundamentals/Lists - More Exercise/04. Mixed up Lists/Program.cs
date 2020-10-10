using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace _04._Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var left = ProcessInputToList();
            var right = ProcessInputToList();
            var resultList = new List<int>();

            int smallerListCount = Math.Min(left.Count, right.Count);
            int startBound = 0;
            int endBound = 0;

            if (left.Count > right.Count)
            {
                GetRangeBounds(left, smallerListCount, out startBound, out endBound);
            }
            else
            {
                right.Reverse();
                GetRangeBounds(right, smallerListCount, out startBound, out endBound);
                //startBound = Math.Min(right[0], right[1]);
                //endBound = Math.Max(right[0], right[1]);
            }
            for (int i = 0; i < smallerListCount; i++)
            {
                resultList.Add(left[i]);
                resultList.Add(right[i]);
                //  resultList.Add(right[right.Count - 1 - i]);
            }

            resultList = resultList
                .Where(n => n > startBound && n < endBound)
                .OrderBy(n => n)
                .ToList();

            if (resultList.Any())
            {
                Console.WriteLine(string.Join(" ", resultList));
            }
        }

        private static void GetRangeBounds(List<int> list, int smallerListCount, out int startBound, out int endBound)
        {
            startBound = Math.Min(list[smallerListCount], list[smallerListCount + 1]);
            endBound = Math.Max(list[smallerListCount], list[smallerListCount + 1]);
        }

        private static List<int> ProcessInputToList()
        {
            List<int> list = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToList();
            return list;
        }
    }
}
