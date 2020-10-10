using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            while (word != "end")
            {
                string reversedWord = "";
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    reversedWord += word[i];
                }
                Console.WriteLine($"{word} = {reversedWord}");
                word = Console.ReadLine();
            }
        }
    }
}
