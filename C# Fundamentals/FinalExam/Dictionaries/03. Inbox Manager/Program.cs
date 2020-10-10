using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> inboxManager = new SortedDictionary<string, List<string>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split("->");
                if (input[0] == "Statistics")
                {
                    break;
                }
                string command = input[0];
                string username = input[1];
                if (command == "Add")
                {
                    if (!inboxManager.ContainsKey(username))
                    {
                        inboxManager[username] = new List<string>();
                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                }
                else if (command == "Send")
                {
                    string email = input[2];
                    inboxManager[username].Add(email);
                }
                else if (command == "Delete")
                {
                    if (inboxManager.ContainsKey(username))
                    {
                        inboxManager.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
            }
            Console.WriteLine($"Users count: {inboxManager.Keys.Count}");
            foreach (var kvp in inboxManager
                .OrderByDescending(x => x.Value.Count))
            {
                string currUser = kvp.Key;
                Console.WriteLine(currUser);
                foreach (var email in kvp.Value)
                {
                    Console.WriteLine($" - {email}");
                }
            }
        }
    }
}
