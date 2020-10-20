using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            string query = Console.ReadLine();

            //Predicate<int> predicate = query == "odd" ? new Predicate<int>((n) => n % 2 != 0) : new Predicate<int>((n) => n % 2 == 0);

            Predicate<int> myPredicate = GetPredicate(query);

            List<int> numbers = new List<int>();
            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (myPredicate(i))
                {
                    numbers.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        static Predicate<int> GetPredicate(string query)
        {
            if (query == "odd")
            {
                return new Predicate<int>((n) => n % 2 != 0);
            }
            else
            {
                return new Predicate<int>((n) => n % 2 == 0);
            }
        }
    }
}
