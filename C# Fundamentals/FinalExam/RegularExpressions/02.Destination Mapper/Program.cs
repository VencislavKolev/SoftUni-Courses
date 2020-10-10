using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=\/])(?<name>[A-Z][a-zA-z]{2,})\1";
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> list = new List<string>();
            int travelPoints = 0;
            foreach (Match match in matches)
            {
                string city = match.Groups["name"].Value;
                travelPoints += city.Length;
                list.Add(city);
            }
            Console.WriteLine($"Destinations: {string.Join(", ", list)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
