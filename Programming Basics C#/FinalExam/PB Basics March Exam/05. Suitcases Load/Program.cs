using System;

namespace _05._Suitcases_Load
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int luggageCounter = 0;
            while (command != "End")
            {
                luggageCounter++;
                double luggageVolume = double.Parse(command);
                if (luggageCounter % 3 == 0)
                {
                    luggageVolume *= 1.1;
                }
                capacity -= luggageVolume;
                if (capacity <= 0)
                {
                    luggageCounter -= 1;
                    Console.WriteLine("No more space!");
                    break;
                }
                command = Console.ReadLine();
            }
            if (capacity >= 0)
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }
            Console.WriteLine($"Statistic: {luggageCounter} suitcases loaded.");
        }
    }
}
