using System;
using System.Linq;
using System.Text;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            while (input != "find")
            {
                string decrypted = "";
                for (int i = 0; i < input.Length; i++)
                {
                    char currChar = input[i];
                    int decreaseValue = keys[i % keys.Length];
                    char newChar = (char)(currChar - decreaseValue);
                    decrypted += newChar;
                }
                string type = decrypted.Substring(decrypted.IndexOf('&') + 1,
                    decrypted.LastIndexOf('&') - (decrypted.IndexOf('&')) - 1);
                string coordinates = decrypted.Substring(decrypted.IndexOf('<') + 1,
                    decrypted.LastIndexOf('>') - (decrypted.IndexOf('<')) - 1);
                Console.WriteLine($"Found {type} at {coordinates}");
                input = Console.ReadLine();
            }
        }
    }
}
