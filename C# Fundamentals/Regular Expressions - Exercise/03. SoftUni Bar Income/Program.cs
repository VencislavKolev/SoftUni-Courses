using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|%$.]*<(?<product>\w+)>[^|%$.]*\|(?<count>\d+)\|[^|%$.]*?(?<price>\d+\.?\d+)\$";
            string input;
            decimal totalIncome = 0m;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    decimal totalPrice = price * count;
                    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
                    totalIncome += totalPrice;
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
