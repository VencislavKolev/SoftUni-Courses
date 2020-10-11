using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> evenNumbers = new Queue<int>();
            foreach (var number in numbers.Where(x => x % 2 == 0))
            {
                evenNumbers.Enqueue(number);
            }
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
