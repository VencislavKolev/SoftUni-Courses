using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int daysCounter = 0;
            int spiceConsumedByWorkers = 0;
            int yield = 0;
            int finalYield = 0;
            while (startingYield >= 100)
            {
                daysCounter++;
                yield += startingYield;
                spiceConsumedByWorkers += 26;
                startingYield -= 10;
                finalYield = (yield - spiceConsumedByWorkers - 26);
            }
            Console.WriteLine(daysCounter);
            Console.WriteLine(finalYield);
        }
    }
}
