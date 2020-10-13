using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" -> ");
                string color = inputArgs[0];
                string[] items = inputArgs[1].Split(',');
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                foreach (var item in items)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }
                    wardrobe[color][item]++;
                }
            }
            string[] clothesToFind = Console.ReadLine().Split();
            string wantedColor = clothesToFind[0];
            string wantedItem = clothesToFind[1];

            foreach (var kvp in wardrobe)
            {
                string color = kvp.Key;
                Console.WriteLine($"{color} clothes:");
                foreach (var (itemKey, itemCount) in kvp.Value)
                {
                    if (color == wantedColor && itemKey == wantedItem)
                    {
                        Console.WriteLine($"* {itemKey} - {itemCount} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {itemKey} - {itemCount}");
                    }
                }
            }
        }
    }
}
