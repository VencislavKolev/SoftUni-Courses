using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfChars = int.Parse(Console.ReadLine());
            int charSum = 0;
            for (int i = 0; i < numberOfChars; i++)
            {
                char englishLetter = char.Parse(Console.ReadLine());
                charSum += englishLetter;
            }
            Console.WriteLine($"The sum equals: {charSum}");
        }
    }
}
