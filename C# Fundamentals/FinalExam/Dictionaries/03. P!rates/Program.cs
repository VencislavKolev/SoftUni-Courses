using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> cityPopulation = new Dictionary<string, int>();
            Dictionary<string, int> cityGold = new Dictionary<string, int>();
            while (true)
            {
                string[] input = Console.ReadLine().Split("||");
                if (input[0] == "Sail")
                {
                    break;
                }
                string city = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);
                if (!cityGold.ContainsKey(city))
                {
                    cityGold[city] = 0;
                    cityPopulation[city] = 0;
                }
                cityGold[city] += gold;
                cityPopulation[city] += population;
            }
            while (true)
            {
                string[] events = Console.ReadLine().Split("=>");
                if (events[0] == "End")
                {
                    break;
                }
                string action = events[0];
                string city = events[1];
                if (action == "Plunder")
                {
                    int people = int.Parse(events[2]);
                    int gold = int.Parse(events[3]);
                    cityPopulation[city] -= people;
                    cityGold[city] -= gold;
                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (cityGold[city] <= 0 || cityPopulation[city] <= 0)
                    {
                        cityGold.Remove(city);
                        cityPopulation.Remove(city);
                        Console.WriteLine($"{city} has been wiped off the map!");
                    }
                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(events[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }
                    else
                    {
                        cityGold[city] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cityGold[city]} gold.");
                    }
                }
            }
            if (cityGold.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else if (cityGold.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityGold.Count} wealthy settlements to go to:");
                foreach (var kvp in cityGold
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    string currCity = kvp.Key;
                    Console.WriteLine($"{currCity} -> Population: {cityPopulation[currCity]} citizens, Gold: {kvp.Value} kg");
                }
            }
        }
    }
}
