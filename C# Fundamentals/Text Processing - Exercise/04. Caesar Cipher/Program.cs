using System;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            string encrypted = "";
            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];
                char newChar = (char)(currChar + 3);
                encrypted += newChar;
            }
            Console.WriteLine(encrypted);
        }
    }
}
