using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> myStack = new Stack<int>(values);
            int totalRacks = 1;
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                int currValue = myStack.Peek();
                myStack.Pop();
                if (sum + currValue < rackCapacity)
                {
                    sum += currValue;
                }
                else if (sum + currValue == rackCapacity)
                {
                    sum += currValue;
                    if (myStack.Count > 0)
                    {
                        totalRacks++;
                        sum = 0;
                    }
                }
                else if (sum + currValue > rackCapacity)
                {
                    totalRacks++;
                    sum = 0;
                    sum += currValue;
                }
            }
            Console.WriteLine(totalRacks);
        }
    }
}
