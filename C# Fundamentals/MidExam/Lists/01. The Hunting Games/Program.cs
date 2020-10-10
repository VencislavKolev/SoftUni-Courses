using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            string input = "";
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] tokens = input.Split();
                string action = tokens[0];
                int index = 0;
                string wordOne = "";
                string wordTwo = "";
                switch (action)
                {
                    case "Delete":
                        index = int.Parse(tokens[1]) + 1;
                        if (index >= 0 && index < words.Count)
                        {
                            words.RemoveAt(index);
                        }
                        break;
                    case "Swap":
                        wordOne = tokens[1];
                        wordTwo = tokens[2];
                        if (words.Contains(wordOne) && words.Contains(wordTwo))
                        {
                            int indexOne = words.IndexOf(wordOne);
                            int indexTwo = words.IndexOf(wordTwo);
                            string temp = words[indexOne];
                            words[indexOne] = words[indexTwo];
                            words[indexTwo] = temp;
                        }
                        break;
                    case "Put":
                        string newWord = tokens[1];
                        index = int.Parse(tokens[2]) - 1;
                        if (index >= 0 && index <= words.Count)
                        {
                            words.Insert(index, newWord);
                        }
                        break;
                    case "Sort":
                        words.Sort((x, y) => y.CompareTo(x));
                        break;
                    case "Replace":
                        wordOne = tokens[1];
                        wordTwo = tokens[2];
                        if (words.Contains(wordTwo))
                        {
                            words[words.IndexOf(wordTwo)] = wordOne;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
