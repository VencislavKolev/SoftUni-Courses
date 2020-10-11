using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsToEnqueue = Console.ReadLine()
                .Split(", ")
                .ToArray();
            Queue<string> songsQueue = new Queue<string>(songsToEnqueue);
            while (songsQueue.Count != 0)
            {
                string action = Console.ReadLine();
                if (action == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (action.Contains("Add"))
                {
                    int firstIndexOfSongName = action.IndexOf(' ') + 1;
                    string songToAdd = action
                        .Substring(firstIndexOfSongName, action.Length - firstIndexOfSongName);
                    if (!songsQueue.Contains(songToAdd))
                    {
                        songsQueue.Enqueue(songToAdd);
                    }
                    else
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                }
                else if (action == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
