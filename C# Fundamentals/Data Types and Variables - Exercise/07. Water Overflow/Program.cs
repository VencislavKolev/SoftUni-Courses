using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = 255;
            int numberOfFills = int.Parse(Console.ReadLine());
            int currentCapacity = 0;

            for (int i = 0; i < numberOfFills; i++)
            {
                int litersWater = int.Parse(Console.ReadLine());
                if (currentCapacity + litersWater <= maxCapacity)
                {
                    currentCapacity += litersWater;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(currentCapacity);
        }
    }
}
