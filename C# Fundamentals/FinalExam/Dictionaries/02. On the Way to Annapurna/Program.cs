using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> storeData = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split("->");
                string command = inputArgs[0];
                string store = inputArgs[1];
                if (command == "Add")
                {
                    string[] items = inputArgs[2].Split(',');
                    if (!storeData.ContainsKey(store))
                    {
                        storeData.Add(store, new List<string>());
                    }
                    foreach (var item in items)
                    {
                        storeData[store].Add(item);
                    }
                }
                else if (command == "Remove")
                {
                    if (storeData.ContainsKey(store))
                    {
                        storeData.Remove(store);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Stores list:");
            foreach (var kvp in storeData
                .OrderByDescending(x => x.Value.Count)
                .ThenByDescending(x => x.Key))
            {
                string store = kvp.Key;
                Console.WriteLine(store);
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine("<<" + item + ">>");
                }
            }
        }
    }
}
