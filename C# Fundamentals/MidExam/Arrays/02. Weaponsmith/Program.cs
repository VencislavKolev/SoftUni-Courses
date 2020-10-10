using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> particles = Console.ReadLine().Split('|').ToList();
            string input = "";
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] commands = input.Split();
                string action = commands[0];
                string currElement = "";
                if (action == "Move")
                {
                    int index = int.Parse(commands[2]);
                    if (commands[1] == "Left")
                    {
                        if (index > 0 && index < particles.Count)
                        {
                            currElement = particles[index];
                            particles.Remove(currElement);
                            particles.Insert(index - 1, currElement);
                        }
                    }
                    else
                    {
                        if (index >= 0 && index < particles.Count - 1)
                        {
                            currElement = particles[index];
                            particles.Remove(currElement);
                            particles.Insert(index + 1, currElement);
                        }
                    }
                }
                else if (action == "Check")
                {
                    if (commands[1] == "Even")
                    {
                        PrintElementsAtEvenIndexes(particles);
                    }
                    else
                    {
                        PrintElementsAtOddIndexes(particles);
                    }
                }
            }

            Console.WriteLine($"You crafted {string.Join("", particles)}!");
        }
        static void PrintElementsAtEvenIndexes(List<string> list)
        {
            string evenElements = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenElements += list[i] + " ";
                }
            }
            Console.WriteLine(evenElements);
        }
        static void PrintElementsAtOddIndexes(List<string> list)
        {
            string oddElements = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 1)
                {
                    oddElements += list[i] + " ";
                }
            }
            Console.WriteLine(oddElements);
        }
    }
}
