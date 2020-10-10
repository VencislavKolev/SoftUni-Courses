using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int wins = 0;
            bool isOutOfEnergy = false;
            while ((command = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(command);
                if (initialEnergy - distance >= 0)
                {
                    initialEnergy -= distance;
                    wins++;
                    if (wins % 3 == 0)
                    {
                        initialEnergy += wins;
                    }
                    continue;
                }
                else
                {
                    isOutOfEnergy = true;
                    break;
                }
            }
            if (isOutOfEnergy)
            {
                Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {initialEnergy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {initialEnergy}");
            }
        }
    }
}
