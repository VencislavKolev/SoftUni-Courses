using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guestData = new Dictionary<string, List<string>>();
            int unlikedMealCount = 0;
            while (true)
            {
                string[] input = Console.ReadLine().Split('-');
                if (input[0] == "Stop")
                {
                    break;
                }
                string command = input[0];
                string guest = input[1];
                string meal = input[2];
                if (command == "Like")
                {
                    if (!guestData.ContainsKey(guest))
                    {
                        guestData[guest] = new List<string>();
                    }
                    else if (guestData[guest].Contains(meal))
                    {
                        continue;
                    }
                    guestData[guest].Add(meal);
                }
                else if (command == "Unlike")
                {

                    if (!guestData.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else if (guestData[guest].Contains(meal))
                    {
                        guestData[guest].Remove(meal);
                        unlikedMealCount++;
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                    }
                    else if (!guestData[guest].Contains(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                }
            }
            foreach (var kvp in guestData
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                string currGuest = kvp.Key;
                List<string> likedMeals = kvp.Value;
                PrintOutput(likedMeals, currGuest);
            }
            Console.WriteLine($"Unliked meals: {unlikedMealCount}");
        }
        static void PrintOutput(List<string> likedMeals, string guest)
        {
            Console.WriteLine($"{guest}: {string.Join(", ", likedMeals)}");
        }
    }
}
