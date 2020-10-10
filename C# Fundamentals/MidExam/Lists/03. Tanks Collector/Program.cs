using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Tanks_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ownedTanks = Console.ReadLine().Split(", ").ToList();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();
                string action = input[0];
                string tank = input[1];
                if (action == "Add")
                {
                    if (!ownedTanks.Contains(tank))
                    {
                        ownedTanks.Add(tank);
                        Console.WriteLine("Tank successfully bought");
                        continue;
                    }
                    Console.WriteLine("Tank is already bought");
                }
                else if (action == "Remove")
                {
                    if (ownedTanks.Contains(tank))
                    {
                        ownedTanks.Remove(tank);
                        Console.WriteLine("Tank successfully sold");
                        continue;
                    }
                    Console.WriteLine("Tank not found");
                }
                else if (action == "Remove At")
                {
                    int index = int.Parse(input[1]);
                    if (IsValidIndex(ownedTanks, index))
                    {
                        ownedTanks.RemoveAt(index);
                        Console.WriteLine("Tank successfully sold");
                        continue;
                    }
                    Console.WriteLine("Index out of range");
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(input[1]);
                    string tankName = input[2];
                    if (!IsValidIndex(ownedTanks, index))
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else if ((IsValidIndex(ownedTanks, index)) &&
                        (!ownedTanks.Contains(tankName)))
                    {
                        ownedTanks.Insert(index, tankName);
                        Console.WriteLine("Tank successfully bought");
                    }
                    else
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                }
            }
            Console.WriteLine(string.Join(", ", ownedTanks));
        }
        static bool IsValidIndex(List<string> tanks, int index)
        {
            if (index >= 0 && index < tanks.Count)
            {
                return true;
            }
            return false;
        }
    }
}
