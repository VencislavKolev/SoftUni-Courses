using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string inputName = Console.ReadLine();
                uniqueNames.Add(inputName);
            }
            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
