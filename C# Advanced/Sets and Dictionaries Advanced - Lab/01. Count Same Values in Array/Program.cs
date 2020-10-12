using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> sameValues = new Dictionary<double, int>();
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            foreach (var number in numbers)
            {
                if (!sameValues.ContainsKey(number))
                {
                    sameValues[number] = 0;
                }
                sameValues[number]++;
            }
            foreach (var (key, value) in sameValues)
            {
                Console.WriteLine($"{key} - {value} times");
            }
        }
    }
}
