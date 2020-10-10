using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();

            double averageNum = numbers.Average();
            //numbers.Sum() * 1.0 / numbers.Count;
            List<int> greaterNums = new List<int>();
            foreach (var item in numbers)
            {
                if (item > averageNum)
                {
                    greaterNums.Add(item);
                }
            }
            if (greaterNums.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }
            greaterNums.Sort((x, y) => y.CompareTo(x));
            if (greaterNums.Count < 5)
            {
                Console.WriteLine(string.Join(" ", greaterNums));
            }
            else if (greaterNums.Count >= 5)
            {
                Console.WriteLine(string.Join(" ", greaterNums.Take(5)));
            }
        }
    }
}
