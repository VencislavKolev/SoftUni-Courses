using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
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
            Queue<int> myQueue = new Queue<int>(elements);
            DeleteFromQueue(s, myQueue);
            if (myQueue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                //ако count е по-голям от 0 => отпечатай най-малкия елемент
                //в противен случай отпечтай 0
                Console.WriteLine(myQueue.Count > 0 ? myQueue.Min() : 0);
            }
            //else if (!myQueue.Contains(x) && myQueue.Count >= 1)
            //{
            //    int smallestElement = myQueue.Min();
            //    Console.WriteLine(smallestElement);
            //}
            //else if (myQueue.Count == 0)
            //{
            //    Console.WriteLine('0');
            //}
        }

        private static void DeleteFromQueue(int s, Queue<int> myQueue)
        {
            for (int i = 0; i < s; i++)
            {
                myQueue.Dequeue();
            }
        }
    }
}
