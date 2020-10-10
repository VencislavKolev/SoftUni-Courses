using System;
using System.Collections.Generic;
using System.Linq;

namespace Plant_Discovery_WithClass
{
    class Program
    {
        static void Main(string[] args)
        {
            // 100/100
            double n = double.Parse(Console.ReadLine());
            Dictionary<string, Plant> plantData = new Dictionary<string, Plant>();
            for (double i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split("<->");
                string plantName = inputArgs[0];
                int rarity = int.Parse(inputArgs[1]);
                if (!plantData.ContainsKey(plantName))
                {
                    Plant plant = new Plant()
                    {
                        Rarity = rarity,
                        AverageRating = 0.0,
                        Rating = new List<double>()
                    };
                    plantData.Add(plantName, plant);
                }
                else
                {
                    plantData[plantName].Rarity = rarity;
                }
            }
            string[] separators = new string[]
            {
                ":", " ", "-"
            };
            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] inputArgs = command.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string action = inputArgs[0];
                string plantName = inputArgs[1];

                if (action == "Rate")
                {
                    if (plantData.ContainsKey(plantName))
                    {
                        double rating = double.Parse(inputArgs[2]);
                        plantData[plantName].Rating.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "Update")
                {
                    if (plantData.ContainsKey(plantName))
                    {
                        int newRarity = int.Parse(inputArgs[2]);
                        plantData[plantName].Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (action == "Reset")
                {
                    if (plantData.ContainsKey(plantName))
                    {
                        plantData[plantName].Rating.Clear();
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

            foreach (var plant in plantData.Keys)
            {
                if (plantData[plant].Rating.Any())
                {
                    plantData[plant].AverageRating = plantData[plant].Rating.Average();
                }
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var kvp in plantData
                .OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(x => x.Value.AverageRating))
            {
                string name = kvp.Key;
                int rarity = kvp.Value.Rarity;
                double averageRating = kvp.Value.AverageRating;
                Console.WriteLine($"- {name}; Rarity: {rarity}; Rating: {averageRating:f2}");
            }
        }
    }
}
class Plant
{
    public int Rarity { get; set; }
    public List<double> Rating { get; set; }
    public double AverageRating { get; set; }
}
