using System;
using System.Text;

namespace _02._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] replace = Console.ReadLine().Split();
            StringBuilder decrypted = new StringBuilder();
            bool isValidText = true;
            for (int i = 0; i < input.Length; i++)
            {
                char oldChar = input[i];
                char newChar = (char)(oldChar - 3);
                decrypted.Append(newChar);
                if (oldChar < 'd' && oldChar != '{' && oldChar != '}' &&
                    oldChar != ',' && oldChar != '|' && oldChar != '#')
                {
                    isValidText = false;
                    break;
                }
            }
            if (isValidText)
            {
                decrypted.Replace(replace[0], replace[1]);
                Console.WriteLine(decrypted);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
