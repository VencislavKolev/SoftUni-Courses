using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            PrintMiddleCharacters(text);
        }
        static void PrintMiddleCharacters(string text)
        {
            if (text.Length % 2 == 0)
            {
                char firstMidSymbol = text[text.Length / 2 - 1];
                char secondMidSymbol = text[text.Length / 2];
                Console.WriteLine($"{firstMidSymbol}{secondMidSymbol}");
            }
            else
            {
                char midSymbol = text[text.Length / 2];
                Console.WriteLine(midSymbol);
            }
        }
    }
}
