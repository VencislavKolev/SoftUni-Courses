using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<seq>[^0-9]+)(?<repeat>[0-9]{1,2})";
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            MatchCollection matches = Regex.Matches(input, pattern);
            List<char> uniqueSymbols = new List<char>();
            foreach (Match match in matches)
            {
                string sequence = match.Groups["seq"].Value.ToUpper();
                int repeat = int.Parse(match.Groups["repeat"].Value);
                if (repeat > 0)
                {
                    for (int i = 0; i < repeat; i++)
                    {
                        sb.Append(sequence);
                    }
                    for (int i = 0; i < sequence.Length; i++)
                    {
                        char currChar = sequence[i];
                        if (!uniqueSymbols.Contains(currChar))
                        {
                            uniqueSymbols.Add(currChar);
                        }
                    }
                }
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(sb.ToString());
        }
    }
}
