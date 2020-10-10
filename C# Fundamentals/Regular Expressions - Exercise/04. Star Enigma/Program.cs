using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destoyedPlanets = new List<string>();
            string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<type>[AD])![^@\-!:>]*->(?<soldierCount>\d+)";
            for (int i = 0; i < n; i++)
            {
                string encrypted = Console.ReadLine();
                int key = SpecialLetterCount(encrypted);
                string decrypted = DecryptedMessage(encrypted, key);
                MatchCollection matches = Regex.Matches(decrypted, pattern);
                foreach (Match match in matches)
                {
                    string planetName = match.Groups["name"].Value;
                    int population = int.Parse(match.Groups["population"].Value);
                    string type = match.Groups["type"].Value;
                    int soldierCount = int.Parse(match.Groups["soldierCount"].Value);
                    if (type == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (type == "D")
                    {
                        destoyedPlanets.Add(planetName);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planetA in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planetA}");
            }
            Console.WriteLine($"Destroyed planets: {destoyedPlanets.Count}");
            foreach (string planetA in destoyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planetA}");
            }
        }
        static string DecryptedMessage(string encrypted, int key)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < encrypted.Length; j++)
            {
                char newChar = (char)(encrypted[j] - key);
                sb.Append(newChar);
            }
            return sb.ToString();
        }

        static int SpecialLetterCount(string message)
        {
            char[] letters = new char[]
                {
                's','t','a','r'
                };
            int numToDecrease = 0;
            for (int j = 0; j < message.Length; j++)
            {
                char currChar = message[j];
                if (letters.Contains(char.ToLower(currChar)))
                {
                    numToDecrease++;
                }
            }
            return numToDecrease;
        }
    }
}
