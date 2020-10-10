using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine().ToLower();
            string text = Console.ReadLine();
            while (text.IndexOf(wordToRemove) != -1)
            {
                int startIndex = text.IndexOf(wordToRemove);
                text = text.Remove(startIndex, wordToRemove.Length);
            }
            Console.WriteLine(text);
        }
    }
}
