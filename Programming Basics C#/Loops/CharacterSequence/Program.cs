﻿using System;

namespace CharacterSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            for (int i = 0; i <= word.Length-1; i++)
            {
                char letter = word[i];
                Console.WriteLine(letter);
            }
        }
    }
}
