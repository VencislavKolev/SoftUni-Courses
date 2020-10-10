using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<int>> peopleData = new SortedDictionary<string, List<int>>();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(':');
                if (inputArgs[0] == "Results")
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
                        peopleData[username].Add(0);//health
                        peopleData[username].Add(0);//energy
                        peopleData[username][1] += int.Parse(inputArgs[3]);
                    }
                    //if user exist,add only energy
                    peopleData[username][0] += int.Parse(inputArgs[2]);
                }
                else if (command == "Attack")
                {
                    string defenderName = inputArgs[2];
                    int damage = int.Parse(inputArgs[3]);
                    if (peopleData.ContainsKey(username) && peopleData.ContainsKey(defenderName))
                    {
                        if (peopleData[defenderName][0] > 0 && peopleData[username][1] > 0)
                        {
                            peopleData[defenderName][0] -= damage;
                            if (peopleData[defenderName][0] <= 0)
                            {
                                peopleData.Remove(defenderName);
                                Console.WriteLine($"{defenderName} was disqualified!");
                            }
                            peopleData[username][1] -= 1;
                            if (peopleData[username][1] == 0)
                            {
                                peopleData.Remove(username);
                                Console.WriteLine($"{username} was disqualified!");
                            }
                        }
                    }
                }
                else if (command == "Delete")
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
            Console.WriteLine($"People count: {peopleData.Count}");
            foreach (var kvp in peopleData.
                OrderByDescending(x => x.Value[0]))
            {
                string currUser = kvp.Key;
                int health = kvp.Value[0];
                int energy = kvp.Value[1];
                Console.WriteLine($"{currUser} - {health} - {energy}");
            }
        }
    }
}
