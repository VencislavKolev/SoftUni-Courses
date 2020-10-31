using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Coordinates_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<name>[!@#$?\w]*)=(?<len>[0-9]+)<<(?<geohash>.+)$";
            string input;
            while ((input = Console.ReadLine()) != "Last note")
            {
                bool isFound = false;
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    int length = int.Parse(match.Groups["len"].Value);
                    string geohash = match.Groups["geohash"].Value;
                    if (geohash.Length == length)
                    {
                        isFound = true;
                        StringBuilder sb = new StringBuilder();
                        foreach (var character in name)
                        {
                            if (char.IsLetterOrDigit(character))
                            {
                                sb.Append(character);
                            }
                        }
                        string nameOfMountain = sb.ToString();
                        Console.WriteLine($"Coordinates found! {nameOfMountain} -> {geohash}");
                    }
                }
                if (!isFound)
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
