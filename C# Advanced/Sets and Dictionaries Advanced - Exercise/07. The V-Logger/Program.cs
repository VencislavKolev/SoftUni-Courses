using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> vloggerFollowers = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, SortedSet<string>> vloggerFollowing = new Dictionary<string, SortedSet<string>>();

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstVlogger = cmdArgs[0];
                ProcessInput(vloggerFollowers, vloggerFollowing, cmdArgs, firstVlogger);
            }

            PrintOutput(vloggerFollowers, vloggerFollowing);


            //Dictionary<string, List<int>> sortedVloggerData = new Dictionary<string, List<int>>();
            //foreach (var kvp in vloggerFollowers)
            //{
            //    string name = kvp.Key;
            //    int followers = kvp.Value.Count;
            //    int following = vloggerFollowing[name].Count;
            //    sortedVloggerData.Add(name, new List<int>());
            //    sortedVloggerData[name].Add(followers);
            //    sortedVloggerData[name].Add(following);
            //}
            //int pos = 1;
            //bool isFirst = true;
            //Console.WriteLine($"The V-Logger has a total of {vloggerFollowers.Count} vloggers in its logs.");
            //foreach (var vlogger in sortedVloggerData
            //    .OrderByDescending(x => x.Value[0])
            //    .ThenBy(x => x.Value[1]))
            //{
            //    string vloggerName = vlogger.Key;
            //    int followers = vlogger.Value[0];
            //    int following = vlogger.Value[1];
            //    Console.WriteLine($"{pos++}. {vloggerName} : {followers} followers, {following} following");
            //    if (followers > 0 && isFirst)
            //    {
            //        isFirst = false;
            //        foreach (var follower in vloggerFollowers[vloggerName])
            //        {
            //            Console.WriteLine($"*  {follower}");
            //        }
            //    }

            //}

        }

        private static void PrintOutput(Dictionary<string, SortedSet<string>> vloggerFollowers, Dictionary<string, SortedSet<string>> vloggerFollowing)
        {
            var sortedVloggerDict = vloggerFollowers
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => vloggerFollowing[kvp.Key].Count)
                .ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggerFollowers.Count} vloggers in its logs.");
            int cnt = 1;
            string mostFamousVlogger = sortedVloggerDict.First().Key;
            Console.WriteLine($"{cnt++}. {mostFamousVlogger} : {vloggerFollowers[mostFamousVlogger].Count} followers, {vloggerFollowing[mostFamousVlogger].Count} following");
            foreach (var follower in vloggerFollowers[mostFamousVlogger])
            {
                Console.WriteLine($"*  {follower}");
            }
            foreach (var vlogger in sortedVloggerDict.Skip(1))
            {
                string name = vlogger.Key;
                Console.WriteLine($"{cnt++}. {name} : {vloggerFollowers[name].Count} followers, {vloggerFollowing[name].Count} following");
            }
        }

        private static void ProcessInput(Dictionary<string, SortedSet<string>> vloggerFollowers, Dictionary<string, SortedSet<string>> vloggerFollowing, string[] cmdArgs, string firstVlogger)
        {
            if (cmdArgs[1] == "joined")
            {
                if (!vloggerFollowers.ContainsKey(firstVlogger))
                {
                    vloggerFollowers[firstVlogger] = new SortedSet<string>();
                    vloggerFollowing[firstVlogger] = new SortedSet<string>();

                }
            }
            else if (cmdArgs[1] == "followed")
            {
                string secondVlogger = cmdArgs[2];
                if (AreValidUsernames(firstVlogger, secondVlogger, vloggerFollowing, vloggerFollowers))
                {
                    if (firstVlogger != secondVlogger &&
                        vloggerFollowing[firstVlogger].Contains(secondVlogger) == false)
                    {
                        vloggerFollowing[firstVlogger].Add(secondVlogger);
                        vloggerFollowers[secondVlogger].Add(firstVlogger);
                    }
                }
            }
        }

        private static bool AreValidUsernames(string firstVlogger, string secondVlogger, Dictionary<string, SortedSet<string>> vloggerFollowing, Dictionary<string, SortedSet<string>> vloggerFollowers)
        {
            return vloggerFollowers.ContainsKey(firstVlogger) &&
                    vloggerFollowers.ContainsKey(secondVlogger) &&
                    vloggerFollowing.ContainsKey(firstVlogger) &&
                    vloggerFollowing.ContainsKey(secondVlogger);
        }
    }
}
