using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input;
            List<string> goodChildren = new List<string>();
            while ((input = Console.ReadLine()) != "end")
            {
                StringBuilder decrypted = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    char newChar = (char)(input[i] - key);
                    decrypted.Append(newChar);
                }
                string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behavior>[GN])!";
                Match match = Regex.Match(decrypted.ToString(), pattern);
                if (match.Success)
                {
                    if (match.Groups["behavior"].Value == "G")
                    {
                        goodChildren.Add(match.Groups["name"].Value);
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, goodChildren));
        }
    }
}
