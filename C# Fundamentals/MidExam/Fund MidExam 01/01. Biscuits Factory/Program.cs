using System;

namespace _01._Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            double biscuitsPerWorkerPerDay = int.Parse(Console.ReadLine());
            double totalWorkers = int.Parse(Console.ReadLine());
            int otherFactoryBiscuitsFor30Days = int.Parse(Console.ReadLine());

            double dailyProduction = Math.Floor(biscuitsPerWorkerPerDay * totalWorkers);
            double thirdDayProduction = Math.Floor(dailyProduction * 0.75);
            double totalProcution = 20 * dailyProduction + 10 * thirdDayProduction;

            Console.WriteLine($"You have produced {totalProcution} biscuits for the past month.");
            double difference = Math.Abs(totalProcution - otherFactoryBiscuitsFor30Days);
            double percentage = difference / otherFactoryBiscuitsFor30Days * 100;
            if (totalProcution > otherFactoryBiscuitsFor30Days)
            {
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else if (totalProcution < otherFactoryBiscuitsFor30Days)
            {
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }
        }
    }
}
