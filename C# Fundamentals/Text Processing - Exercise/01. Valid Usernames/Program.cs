using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            List<string> validNames = new List<string>();
            foreach (string word in usernames.Where(x => x.Length >= 3 && x.Length <= 16))
            {
                bool isValid = true;
                foreach (char symbol in word)
                {
                    if (!(char.IsLetterOrDigit(symbol)
                        || symbol == '-' || symbol == '_'))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    validNames.Add(word);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, validNames));
        }
    }
}
