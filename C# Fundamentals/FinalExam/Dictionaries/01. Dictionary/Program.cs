using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            string[] pairs = input.Split(" | ");
            foreach (var kvp in pairs)
            {
                string[] pair = kvp.Split(": ");
                string word = pair[0];
                string def = pair[1];
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());
                }
                dictionary[word].Add(def);
            }
            string[] wordsToCheck = Console.ReadLine().Split(" | ");
            foreach (var word in wordsToCheck)
            {
                if (dictionary.ContainsKey(word) && dictionary[word].Count > 0)
                {
                    Console.WriteLine(word);
                    foreach (var def in dictionary[word].OrderByDescending(x => x.Length))
                    {
                        Console.WriteLine(" -" + def);
                    }
                }
            }
            string finalAction = Console.ReadLine();
            if (finalAction == "End")
            {
                return;
            }
            else if (finalAction == "List")
            {
                List<string> words = dictionary.Keys.OrderBy(x => x).ToList();
                Console.WriteLine(string.Join(" ", words));
                //dictionary = dictionary.OrderBy(x => x.Key)
                //    .ToDictionary(a => a.Key, b => b.Value);
                //foreach (var word in dictionary.Keys)
                //{
                //    Console.Write(word + " ");
                //}
            }
        }
    }
}
