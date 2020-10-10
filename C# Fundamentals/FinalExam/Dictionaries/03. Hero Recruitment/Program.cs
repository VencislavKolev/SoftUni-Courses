using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> spellBook = new Dictionary<string, List<string>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }
                string command = input[0];
                string heroName = input[1];
                if (command == "Enroll")
                {
                    if (!spellBook.ContainsKey(heroName))
                    {
                        spellBook[heroName] = new List<string>();
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if (command == "Learn")
                {
                    string spellName = input[2];
                    if (IfHeroExists(spellBook, heroName) == false)
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                        continue;
                    }
                    else if (!spellBook[heroName].Contains(spellName))
                    {
                        spellBook[heroName].Add(spellName);
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                    }

                }
                else if (command == "Unlearn")
                {
                    string spellName = input[2];
                    if (IfHeroExists(spellBook, heroName) == false)
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                        continue;
                    }
                    else if (!spellBook[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                    }
                    else
                    {
                        spellBook[heroName].Remove(spellName);
                    }
                }
            }
            Console.WriteLine("Heroes:");
            foreach (var kvp in spellBook
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                string name = kvp.Key;
                List<string> spells = kvp.Value;
                PrintOutput(name, spells);
            }
        }
        static bool IfHeroExists(Dictionary<string, List<string>> spellBook, string heroName)
        {
            if (!spellBook.ContainsKey(heroName))
            {
                return false;
            }
            return true;
        }
        static void PrintOutput(string name, List<string> spells)
        {
            Console.WriteLine($"== {name}: {string.Join(", ", spells)}");
        }
    }
}
