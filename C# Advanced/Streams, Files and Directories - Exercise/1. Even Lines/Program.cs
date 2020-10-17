using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                int cnt = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (cnt % 2 == 0)
                    {
                        line = ReplaceCharacters(line);
                        string reversedLine = ReverseLine(line);
                        Console.WriteLine(reversedLine);
                    }
                    cnt++;
                }
            }

        }
        static string ReverseLine(string line)
        {
            StringBuilder reverseLine = new StringBuilder();
            string[] words = line.Split();
            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[words.Length - 1 - i];
                reverseLine.Append(currWord + " ");
            }
            return reverseLine.ToString().TrimEnd();
        }
        static string ReplaceCharacters(string line)
        {
            char[] charsToReplace = new char[]
            { 
                '-', ',', '.', '!', '?'
            };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                char currChar = line[i];
                if (charsToReplace.Contains(currChar))
                {
                    sb.Append('@');
                }
                else
                {
                    sb.Append(currChar);
                }
            }
            return sb.ToString();
        }
    }
}
