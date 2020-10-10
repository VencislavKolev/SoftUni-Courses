using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string action = tokens[0];
                int index = int.Parse(tokens[1]);
                if (action == "Shoot")
                {
                    int power = int.Parse(tokens[2]);
                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= power;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }

                }
                else if (action == "Add")
                {
                    int value = int.Parse(tokens[2]);
                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, value);
                        continue;
                    }
                    Console.WriteLine("Invalid placement!");
                }
                else if (action == "Strike")
                {
                    int radius = int.Parse(tokens[2]);
                    if (index >= 0 && index < targets.Count)
                    {
                        if (index - radius < 0 || index + radius >= targets.Count)
                        {
                            Console.WriteLine("Strike missed!");
                            continue;
                        }
                        targets.RemoveRange(index - radius, radius * 2 + 1);
                    }
                }
            }
            Console.WriteLine(string.Join("|", targets));
        }
    }
}
