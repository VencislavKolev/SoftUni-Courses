using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> symbolDict = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (!symbolDict.ContainsKey(currChar))
                {
                    symbolDict[currChar] = 0;
                }
                symbolDict[currChar]++;
            }
            foreach (var (symbolKey, symbolValue) in symbolDict)
            {
                Console.WriteLine($"{symbolKey}: {symbolValue} time/s");
            }
        }
    }
}
