using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();
            string[] inputWords = File.ReadAllText("words.txt")
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            String pattern = @"[A-Za-z]+";
            Regex regex = new Regex(pattern);

            using (var reader = new StreamReader("text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string currentSentcence = reader.ReadLine();
                    foreach (Match match in regex.Matches(currentSentcence))
                    {
                        string currWord = match.Value.ToLower();
                        for (int i = 0; i < inputWords.Length; i++)
                        {
                            string wordToCheck = inputWords[i];
                            if (currWord == wordToCheck && !dictionary.ContainsKey(wordToCheck))
                            {
                                dictionary.Add(wordToCheck, 1);
                            }
                            else if (currWord == wordToCheck)
                            {
                                dictionary[wordToCheck]++;
                            }
                        }
                    }
                }
                foreach (var item in dictionary.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("{0} - {1}", item.Key, item.Value);
                }
            }
        }
    }
}
