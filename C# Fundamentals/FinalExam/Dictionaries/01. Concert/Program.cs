using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bandMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandPlayTime = new Dictionary<string, int>();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split("; ");
                if (inputArgs[0] == "start of concert")
                {
                    break;
                }
                string command = inputArgs[0];
                string bandName = inputArgs[1];
                if (command == "Add")
                {
                    if (!bandMembers.ContainsKey(bandName))
                    {
                        CreateBand(bandMembers, bandPlayTime, bandName);
                    }
                    AddMembersToBand(bandMembers, inputArgs, bandName);
                }
                else if (command == "Play")
                {
                    int playTime = int.Parse(inputArgs[2]);
                    if (!bandMembers.ContainsKey(bandName))
                    {
                        CreateBand(bandMembers, bandPlayTime, bandName);
                    }
                    bandPlayTime[bandName] += playTime;
                }
            }
            string outputBandName = Console.ReadLine();

            Console.WriteLine($"Total time: {bandPlayTime.Values.Sum()}");
            foreach (var kvp in bandPlayTime
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                string currBand = kvp.Key;
                int currBandPlayTime = kvp.Value;
                Console.WriteLine($"{currBand} -> {currBandPlayTime}");
            }
            Console.WriteLine(outputBandName);
            foreach (var member in bandMembers[outputBandName])
            {
                Console.WriteLine($"=> {member}");
            }
        }

        private static void AddMembersToBand(Dictionary<string, List<string>> bandMembers, string[] inputArgs, string bandName)
        {
            string[] membersToAdd = inputArgs[2].Split(", ");
            for (int i = 0; i < membersToAdd.Length; i++)
            {
                string member = membersToAdd[i];
                if (!bandMembers[bandName].Contains(member))
                {
                    bandMembers[bandName].Add(member);
                }
            }
        }

        private static void CreateBand(Dictionary<string, List<string>> bandMembers, Dictionary<string, int> bandPlayTime, string bandName)
        {
            bandMembers.Add(bandName, new List<string>());
            bandPlayTime[bandName] = 0;
        }
    }
}
