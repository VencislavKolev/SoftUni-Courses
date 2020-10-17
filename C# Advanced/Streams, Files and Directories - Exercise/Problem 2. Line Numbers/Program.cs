using System;
using System.IO;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    int count = 1;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        int letters = LetterCount(line);
                        int punctuationMarks = PunctuationMarksCount(line);
                        string wordLine = "Line";
                        string textToWrite = $"{wordLine} {count++}: {line} ({letters})({punctuationMarks})";
                        writer.WriteLine(textToWrite);
                    }
                }
            }
        }
        static int PunctuationMarksCount(string line)
        {
            int punctuationMarks = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char currChar = line[i];
                if (char.IsPunctuation(currChar))
                {
                    punctuationMarks++;
                }
            }
            return punctuationMarks;
        }
        static int LetterCount(string line)
        {
            int letterCount = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char currChar = line[i];
                if (char.IsLetter(currChar))
                {
                    letterCount++;
                }
            }
            return letterCount;
        }
    }
}
