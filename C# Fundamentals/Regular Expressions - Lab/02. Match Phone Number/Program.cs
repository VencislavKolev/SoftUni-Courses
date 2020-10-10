using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            string numbers = Console.ReadLine();
            MatchCollection matchedNumbers = Regex.Matches(numbers, regex);
            var matchedPhones = matchedNumbers
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
