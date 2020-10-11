using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> myStack = new Stack<int>(numbers);

            while (true)
            {
                string[] command = Console.ReadLine()
                    .ToLower()
                    .Split();
                if (command[0] == "add")
                {
                    myStack.Push(int.Parse(command[1]));
                    myStack.Push(int.Parse(command[2]));
                }
                else if (command[0] == "remove")
                {
                    int numbersToRemove = int.Parse(command[1]);
                    if (myStack.Count >= numbersToRemove)
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            myStack.Pop();
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"Sum: {myStack.Sum()}");
        }
    }
}
