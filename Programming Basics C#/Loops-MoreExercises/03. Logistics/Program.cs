using System;

namespace _03._Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberLoads = int.Parse(Console.ReadLine());
            double averagePricePerTone = 0;
            double vanPrice = 0;
            double vanCount = 0;
            double truckPrice = 0;
            double truckCount = 0;
            double trainPrice = 0;
            double trainCount = 0;
            int sumLoads = 0;

            for (int i = 0; i < numberLoads; i++)
            {
                int loadWeight = int.Parse(Console.ReadLine());

                if (loadWeight <= 3)
                {
                    vanPrice += loadWeight * 200;
                    vanCount += loadWeight;
                }
                else if (loadWeight >= 4 && loadWeight <= 11)
                {
                    truckPrice += loadWeight * 175;
                    truckCount += loadWeight;
                }
                else if (loadWeight >= 12)
                {
                    trainPrice += loadWeight * 120;
                    trainCount += loadWeight;
                }
                sumLoads += loadWeight;
            }
            averagePricePerTone = (vanPrice + trainPrice + truckPrice) / sumLoads;

            Console.WriteLine($"{averagePricePerTone:f2}");
            Console.WriteLine($"{(vanCount / sumLoads) * 100:f2}%");
            Console.WriteLine($"{(truckCount / sumLoads) * 100:f2}%");
            Console.WriteLine($"{(trainCount / sumLoads) * 100:f2}%");
        }

    }
}
