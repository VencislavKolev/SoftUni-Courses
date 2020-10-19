using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> filterUppercase = word => Char.IsUpper(word[0]);

            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(filterUppercase)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
