using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsPath = Path.Combine("03. Word Count", "words.txt");
            var textPath = Path.Combine("03. Word Count", "text.txt");
            Dictionary<string, int> wordCountDict = new Dictionary<string, int>();
            using (StreamReader wordsReader = new StreamReader(wordsPath))
            {
                List<string> words = wordsReader.ReadLine().Split().ToList();
                using (StreamReader textReader = new StreamReader(textPath))
                {
                    while (!textReader.EndOfStream)
                    {
                        string[] wordsInCurrentLine = textReader.ReadLine()
                            .ToLower()
                            .Split(new char[] { ' ', '-', '.',',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in words)
                        {
                            if (!wordCountDict.ContainsKey(word))
                            {
                                wordCountDict[word] = 0;
                            }
                            foreach (var currWord in wordsInCurrentLine)
                            {
                                if (word == currWord)
                                {
                                    wordCountDict[word]++;
                                }
                            }
                        }
                    }
                }
            }
            wordCountDict = wordCountDict
                .OrderByDescending(x => x.Value)
                .ToDictionary(a => a.Key, b => b.Value);
            using (StreamWriter writeDict = new StreamWriter("Output.txt"))
            {
                foreach (var (wordKey, countValue) in wordCountDict)
                {
                    writeDict.WriteLine($"{wordKey} - {countValue}");
                }
            }
        }
    }
}
