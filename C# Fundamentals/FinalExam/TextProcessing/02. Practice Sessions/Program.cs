using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Practice_Sessions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> roadData = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split("->");
                string command = inputArgs[0];
                string road = inputArgs[1];
                if (command == "Add")
                {
                    if (!roadData.ContainsKey(road))
                    {
                        roadData.Add(road, new List<string>());
                    }
                    string racer = inputArgs[2];
                    roadData[road].Add(racer);
                }
                else if (command == "Move")
                {
                    string racer = inputArgs[2];
                    string nextRoad = inputArgs[3];
                    if (roadData[road].Contains(racer))
                    {
                        roadData[nextRoad].Add(racer);
                        roadData[road].Remove(racer);
                    }
                }
                else if (command == "Close")
                {
                    if (roadData.ContainsKey(road))
                    {
                        roadData.Remove(road);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Practice sessions:");
            foreach (var kvp in roadData
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                string road = kvp.Key;
                Console.WriteLine(road);
                foreach (var racer in roadData[road])
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
