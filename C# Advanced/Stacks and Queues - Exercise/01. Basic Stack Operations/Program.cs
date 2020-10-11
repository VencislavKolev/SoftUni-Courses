using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = parameters[0];
            int s = parameters[1];
            int x = parameters[2];
            Stack<int> myStack = new Stack<int>(elements);
            for (int i = 0; i < s; i++)
            {
                myStack.Pop();
            }
            if (myStack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (!myStack.Contains(x) && myStack.Count >= 1)
            {
                int smallestElement = myStack.Min();
                Console.WriteLine(smallestElement);
            }
            else if (myStack.Count == 0)
            {
                Console.WriteLine('0');
            }
        }
    }
}
