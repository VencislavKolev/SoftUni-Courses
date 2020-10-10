using System;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[i];
                for (int j = 0; j < currWord.Length; j++)
                {
                    result.Append(currWord);
                }
            }
            Console.WriteLine(result);
        }
    }
}
