using System;
using System.Collections.Generic;
using System.Linq;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split('|').ToList();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                string[] tokens = input.Split();
                string action = tokens[0];
                if (action == "Loot")
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        string currItem = tokens[i];
                        if (!chest.Contains(currItem))
                        {
                            chest.Insert(0, currItem);
                        }
                    }
                }
                else if (action == "Drop")
                {
                    int index = int.Parse(tokens[1]);
                    if (index > 0 && index < chest.Count)
                    {
                        chest.Add(chest[index]);
                        chest.RemoveAt(index);
                    }
                }
                else if (action == "Steal")
                {
                    int count = int.Parse(tokens[1]);
                    List<string> stolen = chest.Skip(Math.Min(chest.Count - count, chest.Count)).ToList();
                    Console.WriteLine(string.Join(", ", stolen));
                    for (int i = 0; i < stolen.Count; i++)
                    {
                        chest.Remove(stolen[i]);
                    }
                }
            }
            int itemsLength = 0;
            foreach (var item in chest)
            {
                itemsLength += item.Length;
            }
            double averageGain = itemsLength * 1.0 / chest.Count;
            if (averageGain > 0)
            {
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
