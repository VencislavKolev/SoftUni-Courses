using System;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"([U][$])(?<name>[A-Z][a-z]{2,})([U][$])([P][@][$])(?<pass>[a-z]{5,}\d+)([P][@][$])";
            int successfulRegistrationsCount = 0;
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                Match match = Regex.Match(text, pattern);
                if (match.Success)
                {
                    string username = match.Groups["name"].Value;
                    string password = match.Groups["pass"].Value;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password}");
                    successfulRegistrationsCount++;
                }
                else

                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {successfulRegistrationsCount}");
        }
    }
}
