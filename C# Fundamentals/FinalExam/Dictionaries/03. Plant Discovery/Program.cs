using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->");
                string plant = input[0];
                int rarity = int.Parse(input[1]);
                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, new List<double>());
                }
                plants[plant].Add(rarity);
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(": ");
                if (commands[0] == "Exhibition")
                {
                    break;
                }
                //if plants.contains(plant)
                else if (commands[0] == "Rate")
                {
                    string[] info = commands[1].Split(" - ");
                    string plant = info[0];
                    int rating = int.Parse(info[1]);
                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (commands[0] == "Update")
                {
                    string[] info = commands[1].Split(" - ");
                    string plant = info[0];
                    int newRarity = int.Parse(info[1]);
                    if (plants.ContainsKey(plant))
                    {
                        plants[plant][0] = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (commands[0] == "Reset")
                {
                    string plant = commands[1];
                    if (plants.ContainsKey(plant))
                    {
                        double plantRarityToRemember = plants[plant][0];
                        plants[plant].Clear();
                        plants[plant].Add(plantRarityToRemember);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            foreach (var plant in plants)
            {
                string currPlant = plant.Key;
                double currPlantRarity = plant.Value[0];
                double sum = 0;
                double averageRating = 0;
                if (plant.Value.Count > 1)
                {
                    for (int i = 1; i < plant.Value.Count; i++)
                    {
                        sum += plants[currPlant][i];
                    }
                    averageRating = sum / (plant.Value.Count - 1);
                }
                plants[currPlant].Clear();
                plants[currPlant].Add(currPlantRarity);
                plants[currPlant].Add(averageRating);
            }
            //plants = plants
            //    .OrderByDescending(x => x.Value[0])
            //    .ThenByDescending(x => x.Value[1])
            //    .ToDictionary(a => a.Key, b => b.Value);
            Console.WriteLine("Plants for the exhibition:");
            foreach (var kvp in plants
                .OrderByDescending(x => x.Value[0])
                .ThenByDescending(x => x.Value[1]))
            {
                Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value[0]}; Rating: {kvp.Value[1]:f2}");
            }
        }
    }
}
