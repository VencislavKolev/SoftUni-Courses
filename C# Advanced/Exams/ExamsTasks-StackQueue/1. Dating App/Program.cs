using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] maleValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] femaleValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> femaleQueue = new Queue<int>(femaleValues);
            Stack<int> maleStack = new Stack<int>(maleValues);
            int matchesCount = 0;
            while (maleStack.Count > 0 && femaleQueue.Count > 0)
            {
                int currentFemale = femaleQueue.Peek();
                int currentMale = maleStack.Peek();
                bool isRemoved = false;
                if (currentMale <= 0)
                {
                    maleStack.Pop();
                    isRemoved = true;
                }
                if (currentFemale <= 0)
                {
                    femaleQueue.Dequeue();
                    isRemoved = true;
                }
                if (isRemoved)
                {
                    continue;
                }
                else if (currentFemale % 25 == 0)
                {
                    femaleQueue.Dequeue();
                    if (femaleQueue.Count == 0)
                    {
                        break;
                    }
                    femaleQueue.Dequeue();
                }
                else if (currentMale % 25 == 0)
                {
                    maleStack.Pop();
                    if (maleStack.Count == 0)
                    {
                        break;
                    }
                    maleStack.Pop();
                }
                else if (currentFemale == currentMale)
                {
                    matchesCount++;
                    femaleQueue.Dequeue();
                    maleStack.Pop();
                }
                else if (currentFemale != currentMale)
                {
                    femaleQueue.Dequeue();
                    maleStack.Pop();
                    maleStack.Push(currentMale - 2);
                }
            }
            Console.WriteLine($"Matches: {matchesCount}");
            if (maleStack.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ", maleStack)}");
            }
            else
            {
                Console.WriteLine($"Males left: none");
            }
            if (femaleQueue.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", femaleQueue)}");
            }
            else
            {
                Console.WriteLine($"Females left: none");
            }
        }
    }
}
