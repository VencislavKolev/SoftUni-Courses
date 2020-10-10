using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char startChar = char.Parse(Console.ReadLine());
            char endChar = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int asciiSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (currChar > startChar && currChar < endChar)
                {
                    asciiSum += currChar;
                }
            }
            Console.WriteLine(asciiSum);
        }
    }
}
