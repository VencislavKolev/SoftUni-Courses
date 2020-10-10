using System;
using System.Text.RegularExpressions;

namespace _02._Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"[|](?<name>[A-Z]+)[|]:[#](?<title>[A-Za-z]+ [A-Za-z]+)[#]";
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string bossName = match.Groups["name"].Value;
                    string title = match.Groups["title"].Value;
                    Console.WriteLine($"{bossName}, The {title}");
                    Console.WriteLine($">> Strength: {bossName.Length}");
                    Console.WriteLine($">> Armour: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
