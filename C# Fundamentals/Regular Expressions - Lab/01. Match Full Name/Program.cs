using System;
using System.Text.RegularExpressions;
namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b([A-Z][a-z]+) [A-Z][a-z]+\b";
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match name in matches)
            {
                Console.Write(name.Value + " ");
            }
        }
    }
}
