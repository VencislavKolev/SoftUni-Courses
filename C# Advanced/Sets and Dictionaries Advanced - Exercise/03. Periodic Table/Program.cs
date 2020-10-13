using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            SortedSet<string> chemicalElements = new SortedSet<string>();
            for (int i = 0; i < lines; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                foreach (var element in inputArgs)
                {
                    chemicalElements.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ", chemicalElements));
        }
    }
}
