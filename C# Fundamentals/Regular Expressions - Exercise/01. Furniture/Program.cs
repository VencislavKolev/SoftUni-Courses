using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-Z]*[a-z]*)<<(?<price>\d*\.?\d+)!(?<quantity>\d*)";
            List<string> furniture = new List<string>();
            decimal totalPrice = 0m;
            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    furniture.Add(name);
                    totalPrice += price * quantity;
                }
            }
            Console.WriteLine("Bought furniture:");
            foreach (string name in furniture)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
