using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            GetCharsInBetween(first, second);
        }
        static void GetCharsInBetween(char startSymbol, char endSymbol)
        {
            int asciiStart = Math.Min(startSymbol, endSymbol);
            int asciiEnd = Math.Max(startSymbol, endSymbol);
            for (int asciiCode = asciiStart + 1; asciiCode < asciiEnd; asciiCode++)
            {
                char symbol = (char)asciiCode;
                Console.Write(symbol + " ");
            }
        }
    }
}
