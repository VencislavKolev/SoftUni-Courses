using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQty = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> myQueue = new Queue<int>(orders);
            Console.WriteLine(myQueue.Max());
            for (int i = 0; i < orders.Length; i++)
            {
                int currOrder = myQueue.Peek();
                if (foodQty - currOrder >= 0)
                {
                    foodQty -= currOrder;
                    myQueue.Dequeue();
                }
            }
            if (myQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", myQueue)}");
            }
        }
    }
}
