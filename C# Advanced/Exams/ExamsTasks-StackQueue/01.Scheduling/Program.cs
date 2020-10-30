using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            // thread queue
            //task stack
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ") //strsplit options
                .Select(int.Parse));

            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                int currThread = threads.Peek();
                int currTask = tasks.Peek();
                if (currTask == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {taskToBeKilled}");
                    break;
                }
                if (currThread >= currTask)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
