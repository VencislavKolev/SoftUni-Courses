using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(?<!.)([$|%])(?<tag>[A-Z][a-z]{2,})\1: [[](?<one>[0-9]+)[]]\|[[](?<two>[0-9]+)[]]\|[[](?<three>[0-9]+)[]]\|(?!.)";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    List<char> chars = new List<char>();
                    string tag = match.Groups["tag"].Value;
                    int one = int.Parse(match.Groups["one"].Value);
                    int two = int.Parse(match.Groups["two"].Value);
                    int three = int.Parse(match.Groups["three"].Value);
                    chars.Add((char)one);
                    chars.Add((char)two);
                    chars.Add((char)three);
                    Console.WriteLine($"{tag}: {string.Join("", chars)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
