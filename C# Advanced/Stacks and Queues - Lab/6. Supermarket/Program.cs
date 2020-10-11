using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> myQueue = new Queue<string>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Paid")
                {
                    if (myQueue.Any())
                    {
                        while (myQueue.Count > 0)
                        {
                            Console.WriteLine(myQueue.Dequeue());
                        }
                        myQueue.TrimExcess();
                    }
                }
                else
                {
                    myQueue.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{myQueue.Count} people remaining.");
        }
    }
}
