using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            int result = VowelsCount(text);
            Console.WriteLine(result);
        }
        static int VowelsCount(string text)
        {
            int vowelCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char currSymbol = text[i];
                if (IsVowel(currSymbol))
                {
                    vowelCount++;
                }
            }
            return vowelCount;
        }
        static bool IsVowel(char symbol)
        {
            return symbol == 'a' || symbol == 'o' || symbol == 'u'
                || symbol == 'e' || symbol == 'i';
        }
    }
}
