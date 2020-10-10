using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            SortedDictionary<string, List<int>> peopleData = new SortedDictionary<string, List<int>>();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split('=');
                if (inputArgs[0] == "Statistics")
                {
                    break;
                }
                string command = inputArgs[0];
                string username = inputArgs[1];
                if (command == "Add")
                {
                    if (!peopleData.ContainsKey(username))
                    {
                        peopleData.Add(username, new List<int>());
                        peopleData[username].Add(0);//sent
                        peopleData[username].Add(0);//received
                        peopleData[username][0] += int.Parse(inputArgs[2]);
                        peopleData[username][1] += int.Parse(inputArgs[3]);
                    }
                }
                else if (command == "Message")
                {
                    string receiver = inputArgs[2];
                    if (peopleData.ContainsKey(username) && peopleData.ContainsKey(receiver))
                    {
                        peopleData[username][0]++;
                        peopleData[receiver][1]++;
                        if (peopleData[username][0] + peopleData[username][1] == capacity)
                        {
                            peopleData.Remove(username);
                            Console.WriteLine($"{username} reached the capacity!");
                        }
                        if (peopleData[receiver][1] + peopleData[receiver][0] == capacity)
                        {
                            peopleData.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }
                else if (command == "Empty")
                {
                    if (peopleData.ContainsKey(username))
                    {
                        peopleData.Remove(username);
                    }
                    else if (username == "All")
                    {
                        peopleData.Clear();
                    }
                }
            }
            Console.WriteLine($"Users count: {peopleData.Count}");
            foreach (var kvp in peopleData
                .OrderByDescending(x => x.Value[1]))
            {
                string user = kvp.Key;
                int messages = kvp.Value.Sum();
                Console.WriteLine($"{user} - {messages}");
            }
        }
    }
}
