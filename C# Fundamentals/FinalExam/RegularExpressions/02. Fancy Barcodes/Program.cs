using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"@#+(?<main>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string main = match.Groups["main"].Value;
                    string productGroup = "";
                    foreach (var symb in main)
                    {
                        if (char.IsDigit(symb))
                        {
                            productGroup += symb;
                        }
                    }
                    if (productGroup == string.Empty)
                    {
                        productGroup = "00";
                    }
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
