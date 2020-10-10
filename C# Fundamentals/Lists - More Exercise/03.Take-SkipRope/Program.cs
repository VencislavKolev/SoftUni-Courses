using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Take_SkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string encrypted = Console.ReadLine();
            List<int> digits = new List<int>();
            //var nums = encrypted
            //    .Where(char.IsDigit)
            //    .ToList();

            //string pattern = @"\d";
            //MatchCollection matches = Regex.Matches(encrypted, pattern);
            //foreach (Match match in matches)
            //{
            //    if (match.Success)
            //    {
            //        int digit = int.Parse(match.Value);
            //        digits.Add(digit);
            //    }
            //}

            //if (char.IsDigit(symbol))
            //{
            //    digits.Add(int.Parse(symbol.ToString()));
            //}
            for (int i = 0; i < encrypted.Length; i++)
            {
                char symbol = encrypted[i];
                int parsedDigit;
                bool isDigit = int.TryParse(symbol.ToString(), out parsedDigit);
                if (isDigit)
                {
                    digits.Add(parsedDigit);
                    encrypted = encrypted.Remove(i, 1);
                    i--;
                }
            }
            List<int> takeList = digits
                .Where((element, index) => index % 2 == 0)
                .ToList();
            List<int> skipList = digits
                .Where((element, index) => index % 2 != 0)
                .ToList();

            StringBuilder decrypted = new StringBuilder();
            int passedChars = 0;

            for (int i = 0; i < digits.Count / 2; i++)
            {
                int takeCount = takeList[i];
                int skipCount = skipList[i];

                decrypted.Append(encrypted
                    .Skip(passedChars)
                    .Take(takeCount)
                    .ToArray());
                passedChars += skipCount + takeCount;
            }
            Console.WriteLine(decrypted);
        }
    }
}
