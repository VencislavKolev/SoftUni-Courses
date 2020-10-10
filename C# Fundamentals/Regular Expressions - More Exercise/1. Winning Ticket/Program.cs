using System;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTickets = Console.ReadLine().Split(new string[] { " ", ", ", "," }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"([$]{6,}|[@]{6,}|[#]{6,}|[\^]{6,})";
            foreach (var ticket in inputTickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                string leftSide = ticket.Substring(0, 10);
                Match leftMatch = Regex.Match(leftSide, pattern);
                string rightSide = ticket.Substring(10, 10);
                Match rightMatch = Regex.Match(rightSide, pattern);

                if (leftMatch.Success && rightMatch.Success
                 && (leftMatch.Value[0] == rightMatch.Value[0]))
                {
                    int matchLength = Math.Min(leftMatch.Value.Length, rightMatch.Value.Length);
                    char matchSymbol = leftMatch.Value[0];
                    if (matchLength == 10)
                    {
                        Console.WriteLine($@"ticket ""{ticket}"" - {matchLength}{matchSymbol} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($@"ticket ""{ticket}"" - {matchLength}{matchSymbol}");
                    }
                }
                else
                {
                    Console.WriteLine($@"ticket ""{ticket}"" - no match");
                }
            }
        }
    }
}
