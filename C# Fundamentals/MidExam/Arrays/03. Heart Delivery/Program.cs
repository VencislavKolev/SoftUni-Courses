using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            string input = "";
            int cuppidIndex = 0;
            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] commands = input.Split();
                string action = commands[0];
                int jumpLength = int.Parse(commands[1]);
                if (action == "Jump")
                {
                    if (cuppidIndex + jumpLength < arr.Length)
                    {
                        cuppidIndex += jumpLength;
                        AfterCupidVisit(arr, cuppidIndex);
                    }
                    else if (cuppidIndex + jumpLength > arr.Length - 1)
                    {
                        cuppidIndex = 0;
                        AfterCupidVisit(arr, cuppidIndex);
                    }
                }
            }
            int noValentinesDayCount = 0;
            foreach (var house in arr)
            {
                if (house != 0)
                {
                    noValentinesDayCount++;
                }
            }
            Console.WriteLine($"Cupid's last position was {cuppidIndex}.");
            if (noValentinesDayCount == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {noValentinesDayCount} places.");
            }
        }
        static int[] AfterCupidVisit(int[] arr, int cuppidIndex)
        {
            if (arr[cuppidIndex] == 0)
            {
                Console.WriteLine($"Place {cuppidIndex} already had Valentine's day.");
            }
            else if ((arr[cuppidIndex] > 0) && (arr[cuppidIndex] - 2 >= 0))
            {
                arr[cuppidIndex] -= 2;
                if (arr[cuppidIndex] == 0)
                {
                    Console.WriteLine($"Place {cuppidIndex} has Valentine's day.");
                }
            }
            return arr;
        }
    }
}
