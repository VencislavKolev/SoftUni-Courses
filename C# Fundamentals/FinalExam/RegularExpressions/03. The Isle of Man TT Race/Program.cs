using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {           
                string input = Console.ReadLine();
                string lenPattern = @"=(\d+)!!";
                Match lenMatch = Regex.Match(input, lenPattern);
                if (lenMatch.Success)
                {
                    int length = int.Parse(lenMatch.Groups[1].Value);
                    string pattern = $@"([#$%\*&])(?<name>[A-Za-z]+)\1=(?<len>\d+)!!(?<message>.{{{length}}})$";
                    Match match = Regex.Match(input, pattern);

                    if (match.Success)
                    {
                        string name = match.Groups["name"].Value;
                        string message = match.Groups["message"].Value;
                        StringBuilder decryptedGeoHashCode = new StringBuilder();
                        for (int i = 0; i < message.Length; i++)
                        {
                            int newAsciiValue = message[i] + length;
                            decryptedGeoHashCode.Append((char)newAsciiValue);
                        }
                        Console.WriteLine($"Coordinates found! {name} -> {decryptedGeoHashCode.ToString()}");
                        break;
                    }
                }
                Console.WriteLine("Nothing found!");
            }
        }
    }
}
