using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(?<start>[\W]+|[\w]+|[\d]+)[>](?<first>[\d]{3})\|(?<sec>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<fourth>[^<>]{3})[<]\k<start>";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    StringBuilder encryptedPassword = new StringBuilder();
                    string first = match.Groups["first"].Value;
                    string sec = match.Groups["sec"].Value;
                    string third = match.Groups["third"].Value;
                    string fourth = match.Groups["fourth"].Value;
                    encryptedPassword.Append(first + sec + third + fourth);
                    Console.WriteLine($"Password: {encryptedPassword}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
