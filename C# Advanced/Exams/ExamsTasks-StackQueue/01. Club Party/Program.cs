using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            List<string> data = Console.ReadLine()
                .Split()
                .Reverse()
                .ToList();

            Dictionary<char, List<int>> hallData = new Dictionary<char, List<int>>();
            List<char> hallNames = new List<char>();
            for (int i = 0; i < data.Count; i++)
            {
                char currChar;
                int currGuestCount;
                if (char.TryParse(data[i], out currChar) && char.IsLetter(currChar))
                {
                    hallNames.Add(currChar);
                    hallData[currChar] = new List<int>();
                }
                else if (int.TryParse(data[i], out currGuestCount))
                {
                    if (hallNames.Any())
                    {
                        int currSum = hallData[hallNames[0]].Sum();
                        if (currSum + currGuestCount <= capacity)
                        {
                            hallData[hallNames[0]].Add(currGuestCount);
                        }
                        else
                        {
                            char firstHall = hallNames[0];
                            Console.WriteLine($"{firstHall} -> {string.Join(", ", hallData[firstHall])}");
                            hallNames.Remove(firstHall);
                            i--;
                            //if (hallNames.Any())
                            //{
                            //    hallData[hallNames[0]] = new List<int>();
                            //    hallData[hallNames[0]].Add(currGuestCount);
                            //}
                        }
                    }
                }
            }
        }
    }
}
