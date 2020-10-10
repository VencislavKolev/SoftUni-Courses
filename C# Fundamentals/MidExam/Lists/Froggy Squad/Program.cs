using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine().Split().ToList();
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Contains("Print"))
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                string frogName = string.Empty;
                int index = 0;
                int count = 0;
                if (action == "Join")
                {
                    frogName = commands[1];
                    if (!frogs.Contains(frogName))
                    {
                        frogs.Add(frogName);
                    }
                }
                else if (action == "Jump")
                {
                    frogName = commands[1];
                    index = int.Parse(commands[2]);
                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.Insert(index, frogName);
                    }
                }
                else if (action == "Dive")
                {
                    index = int.Parse(commands[1]);
                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.RemoveAt(index);
                    }
                }
                else if (action == "First")
                {
                    count = int.Parse(commands[1]);
                    var result = frogs.Take(Math.Min(count, frogs.Count)).ToList();
                    Console.WriteLine(string.Join(" ", result));
                }
                else if (action == "Last")
                {
                    count = int.Parse(commands[1]);
                    var result = frogs.Skip(Math.Min(frogs.Count - count, frogs.Count)).ToList();
                    Console.WriteLine(string.Join(" ", result));
                }
            }
            if (input.Contains("Reverse"))
            {
                frogs.Reverse();
            }
            Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
            return;
        }
    }
}
