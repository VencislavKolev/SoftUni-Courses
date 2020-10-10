using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> mirrorWords = new List<string>();
            //  Dictionary<string, string> mirrorWords = new Dictionary<string, string>();
            string pattern = @"([@#]{1})(?<wordOne>[A-Za-z]{3,})\1{2}(?<wordTwo>[A-Za-z]{3,})\1";
            MatchCollection matches = Regex.Matches(text, pattern);
            int wordPairsCount = matches.Count;
            foreach (Match match in matches)
            {
                string wordOne = match.Groups["wordOne"].Value;
                string wordTwo = match.Groups["wordTwo"].Value;
                if (wordOne.Length == wordTwo.Length)
                {
                    char[] arr = wordTwo.ToCharArray();
                    Array.Reverse(arr);
                    string wordTwoReversed = new string(arr);
                    //bool isMatch = true;
                    //for (int i = 0; i < wordOne.Length; i++)
                    //{
                    //    if (wordOne[i] != wordTwoReversed[i])
                    //    {
                    //        isMatch = false;
                    //    }
                    //}
                    if (wordOne == wordTwoReversed)
                    {
                        string mirrorPair = wordOne + " <=> " + wordTwo;
                        mirrorWords.Add(mirrorPair);
                    }
                }
            }
            if (wordPairsCount == 0)
            {
                Console.WriteLine("No word pairs found!");

            }
            else
            {
                Console.WriteLine($"{wordPairsCount} word pairs found!");
            }
            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}
