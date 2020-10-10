using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> peopleInwagon = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
            int maxWagonCapacity = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(" ", FinalList(peopleInwagon, maxWagonCapacity)));
        }
        static List<int> FinalList(List<int> originalList, int maxCapacity)
        {
            List<int> outputList = new List<int>();
            for (int i = 0; i < originalList.Count; i++)
            {
                outputList.Add(originalList[i]);
            }
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split().ToArray();
                if (command[0] == "Add")
                {
                    int passengersInNewWagon = int.Parse(command[1]);
                    outputList.Add(passengersInNewWagon);
                    continue;
                }
                else
                {
                    int addPassengersToExistingWagons = int.Parse(command[0]);
                    for (int i = 0; i < outputList.Count; i++)
                    {
                        int currWagonCapacity = Convert.ToInt32(outputList[i]);
                        int updatedCapacity = currWagonCapacity + addPassengersToExistingWagons;
                        if (updatedCapacity <= maxCapacity)
                        {
                            outputList.RemoveAt(i);
                            outputList.Insert(i, updatedCapacity);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return outputList;
        }
    }
}
