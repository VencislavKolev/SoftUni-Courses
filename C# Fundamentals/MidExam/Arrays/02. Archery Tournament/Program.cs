using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _02._Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split("|").Select(int.Parse).ToArray();
            string input = "";
            int points = 0;
            while ((input = Console.ReadLine()) != "Game over")
            {
                string[] commands = input.Split("@");
                string action = commands[0];
                int index = 0;
                int length = 0;
                if (action == "Shoot Left")
                {
                    index = int.Parse(commands[1]);
                    if (index >= 0 && index < arr.Length)
                    {
                        length = int.Parse(commands[2]);
                        length = length % arr.Length;
                        for (int i = 0; i < length; i++)
                        {
                            index--;
                            if (index < 0)
                            {
                                index = arr.Length - 1;
                            }
                        }
                        if (arr[index] >= 5)
                        {
                            points += 5;
                            arr[index] -= 5;
                        }
                        else if (arr[index] > 0)
                        {
                            points += arr[index];
                            arr[index] = 0;
                        }
                    }
                }
                else if (action == "Shoot Right")
                {
                    index = int.Parse(commands[1]);
                    if (index >= 0 && index < arr.Length)
                    {
                        length = int.Parse(commands[2]);
                        length = length % arr.Length;
                        for (int i = 0; i < length; i++)
                        {
                            index++;
                            if (index > arr.Length - 1)
                            {
                                index = 0;
                            }
                        }
                        if (arr[index] >= 5)
                        {
                            points += 5;
                            arr[index] -= 5;
                        }
                        else if (arr[index] > 0)
                        {
                            points += arr[index];
                            arr[index] = 0;
                        }
                    }
                }
                else if (action == "Reverse")
                {
                    Array.Reverse(arr);
                }
            }
            Console.WriteLine(string.Join(" - ", arr));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
