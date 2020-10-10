using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"[!](?<command>[A-Z][a-z]{2,})[!]:[[](?<message>[A-Za-z]{8,})[]]";
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    List<int> asciiValues = new List<int>();
                    string message = match.Groups["message"].Value;
                    string command = match.Groups["command"].Value;
                    for (int j = 0; j < message.Length; j++)
                    {
                        asciiValues.Add(message[j]);
                    }
                    Console.WriteLine($"{command}: {string.Join(" ", asciiValues)}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
