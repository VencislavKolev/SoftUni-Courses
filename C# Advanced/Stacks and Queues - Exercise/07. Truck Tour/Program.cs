using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] pumpDetails = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                pumps.Enqueue(pumpDetails);
            }
            int startPumpIndex = 0;
            while (true)
            {
                bool startPointFound = true;
                int fuelAmount = 0;
                foreach (var pump in pumps)
                {
                    fuelAmount += pump[0];
                    if (fuelAmount < pump[1])
                    {
                        startPointFound = false;
                        break;
                    }
                    fuelAmount -= pump[1];
                }
                if (startPointFound)
                {
                    break;
                }
                pumps.Enqueue(pumps.Dequeue());
                startPumpIndex++;
            }
            Console.WriteLine(startPumpIndex);
        }
    }
}
