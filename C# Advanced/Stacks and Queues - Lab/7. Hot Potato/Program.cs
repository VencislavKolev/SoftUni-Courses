using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            int toss = int.Parse(Console.ReadLine());
            Queue<string> players = new Queue<string>(names);
            int tossCount = 1;
            while (players.Count > 1)
            {
                if (toss == tossCount)
                {
                    Console.WriteLine($"Removed {players.Dequeue()}");
                    tossCount = 1;
                }
                else
                {
                    tossCount++;
                    string playerToEndOfQueue = players.Dequeue();
                    players.Enqueue(playerToEndOfQueue);
                }
            }
            Console.WriteLine($"Last is {players.Peek()}");
        }
    }
}
