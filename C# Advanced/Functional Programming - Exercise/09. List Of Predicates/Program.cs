using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endBound = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct() //removes duplicates
                .ToArray();

            Func<int[], List<int>> processFunc = new Func<int[], List<int>>((arr) =>
              {
                  List<int> numbers = new List<int>();
                  for (int i = 1; i <= endBound; i++)
                  {
                      int currNum = i;
                      bool isDivisibleToAll = true;
                      foreach (var divider in dividers)
                      {
                          if (currNum % divider != 0)
                          {
                              isDivisibleToAll = false;
                          }
                      }
                      if (isDivisibleToAll)
                      {
                          numbers.Add(currNum);
                      }
                  }
                  return numbers;
              });

            List<int> divisibleNumbers = processFunc(dividers);

            Console.WriteLine(string.Join(" ", divisibleNumbers));
        }
    }
}
