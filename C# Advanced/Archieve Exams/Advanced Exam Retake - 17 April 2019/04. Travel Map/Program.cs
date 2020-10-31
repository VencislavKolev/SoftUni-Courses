using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Travel_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> mapDict = new Dictionary<string, Dictionary<string, int>>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(" > ");
                string country = cmdArgs[0];
                string town = cmdArgs[1];
                int cost = int.Parse(cmdArgs[2]);
                if (!mapDict.ContainsKey(country))
                {
                    mapDict[country] = new Dictionary<string, int>();
                }
                if (!mapDict[country].ContainsKey(town))
                {
                    mapDict[country][town] = cost;
                }
                else
                {
                    int existingCost = mapDict[country][town];
                    int lowerCost = Math.Min(existingCost, cost);
                    mapDict[country][town] = lowerCost;
                }
            }
            mapDict = mapDict.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key,
                x => x.Value.OrderBy(y => y.Value).ToDictionary(y => y.Key, y => y.Value));

            foreach (var country in mapDict)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(country.Key + " -> ");
                foreach (var kvp in country.Value)
                {
                    sb.Append(kvp.Key + " -> " + kvp.Value + " ");
                }
                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}