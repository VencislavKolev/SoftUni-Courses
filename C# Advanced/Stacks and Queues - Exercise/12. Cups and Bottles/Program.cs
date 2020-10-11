using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] bottleCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> bottles = new Stack<int>(bottleCapacity);
            Queue<int> cups = new Queue<int>(cupsCapacity);
            int wastedWater = 0;
            while (cups.Any() && bottles.Any())
            {
                int currBottle = bottles.Pop();
                int currCup = cups.Peek();
                if (currBottle >= currCup)
                {
                    wastedWater += currBottle - currCup;
                    cups.Dequeue();
                }
                else if (currCup > currBottle)
                {
                    currCup -= currBottle;
                    while (true)
                    {
                        int newBottle = bottles.Pop();
                        if (newBottle >= currCup)
                        {
                            wastedWater += newBottle - currCup;
                            cups.Dequeue();
                            break;
                        }
                        else
                        {
                            currCup -= newBottle;
                        }
                        if (bottles.Count == 0)
                        {
                            break;
                        }
                    }
                }

            }
            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
