using System;
using System.Collections.Generic;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split();

            Func<string[], List<string>> processArr = new Func<string[], List<string>>((names) =>
            {
                List<string> processed = new List<string>();
                foreach (var name in names)
                {
                    if (name.Length <= length)
                    {
                        processed.Add(name);
                    }
                }
                return processed;
            });

            List<string> processedNumbers = processArr(names);
            Console.WriteLine(string.Join(Environment.NewLine, processedNumbers));
        }
    }
}
