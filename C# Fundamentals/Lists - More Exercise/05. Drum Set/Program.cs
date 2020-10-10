using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal savings = decimal.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> initial = new List<int>(drumSet);
            string command;
            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);
                for (int i = 0; i < drumSet.Count; i++)
                {
                    if (drumSet[i] - hitPower > 0)
                    {
                        drumSet[i] -= hitPower;
                    }
                    else
                    {
                        int replacementPrice = initial[i] * 3;
                        if (savings - replacementPrice >= 0)
                        {
                            savings -= replacementPrice;
                            drumSet[i] = initial[i];
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            initial.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}
