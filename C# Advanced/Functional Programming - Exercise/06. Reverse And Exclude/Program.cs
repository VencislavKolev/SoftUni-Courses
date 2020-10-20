using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            int numToDivideWith = int.Parse(Console.ReadLine());

            Func<int[], List<int>> processArr = new Func<int[], List<int>>((arr) =>
              {
                  List<int> processed = new List<int>();
                  foreach (var num in arr)
                  {
                      if (num % numToDivideWith != 0)
                      {
                          processed.Add(num);
                      }
                  }
                  return processed;
              });

            List<int> processedNumbers = processArr(arr);
            Console.WriteLine(string.Join(" ", processedNumbers));
        }
    }
}
