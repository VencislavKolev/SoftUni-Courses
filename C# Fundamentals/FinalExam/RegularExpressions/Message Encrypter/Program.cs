using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"([*|@])(?<tag>[A-Z][a-z]{2,})\1: [[](?<one>[A-Za-z])[]]\|[[](?<two>[A-Za-z])[]]\|[[](?<three>[A-Za-z])[]]\|(?!.)";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    List<int> asciiNumbers = new List<int>();
                    string tag = match.Groups["tag"].Value;
                    char one = char.Parse(match.Groups["one"].Value);
                    char two = char.Parse(match.Groups["two"].Value);
                    char three = char.Parse(match.Groups["three"].Value);
                    asciiNumbers.Add(one);
                    asciiNumbers.Add(two);
                    asciiNumbers.Add(three);
                    Console.WriteLine($"{tag}: {string.Join(" ", asciiNumbers)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
