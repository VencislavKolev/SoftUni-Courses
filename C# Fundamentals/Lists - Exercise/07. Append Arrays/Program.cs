using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] numsAsString = Console.ReadLine()
            //.Split("|").Reverse().ToArray();
            
            List<string> numsAsString = Console.ReadLine()
            .Split("|").Reverse().ToList();
            List<int> appendedArr = new List<int>();
            foreach (var currStr in numsAsString)
            {
                appendedArr.AddRange(currStr.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList());
            }
            Console.WriteLine(string.Join(" ", appendedArr));
        }
    }
}
