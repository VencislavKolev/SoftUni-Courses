using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = new Dictionary<string, int>();
            string[] validNames = Console.ReadLine().Split(", ");
            string input = "";
            while ((input = Console.ReadLine()) != "end of race")
            {
                string pattern = @"[A-Za-z]|\d";
                string name = "";
                int distance = 0;
                MatchCollection letters = Regex.Matches(input, pattern);
                foreach (Match match in letters)
                {
                    char[] currSymbol = match.Value.ToCharArray();
                    if (char.IsLetter(currSymbol[0]))
                    {
                        name += match.Value;
                    }
                    else if (char.IsDigit(currSymbol[0]))
                    {
                        distance += int.Parse(match.Value);
                    }
                }
                if (validNames.Contains(name))
                {
                    if (!racers.ContainsKey(name))
                    {
                        racers[name] = 0;
                    }
                    racers[name] += distance;
                }
            }
            var top3 = racers.OrderByDescending(x => x.Value)
                .Take(3)
                .ToDictionary(a => a.Key, b => b.Value);
            List<string> top3Names = new List<string>();
            foreach (var kvp in top3)
            {
                top3Names.Add(kvp.Key);
            }
            Console.WriteLine($"1st place: {top3Names[0]}");
            Console.WriteLine($"2nd place: {top3Names[1]}");
            Console.WriteLine($"3rd place: {top3Names[2]}");
        }
    }
}
