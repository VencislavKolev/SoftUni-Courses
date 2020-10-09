using System;

namespace SpeedInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());
            string speedStr = string.Empty;    // или ""
            if (speed <= 10)
            {
                speedStr = "slow";
                //Console.WriteLine("slow");
            }
            else if (speed <= 50)
            {
                speedStr = "average";
                //Console.WriteLine("average");
            }
            else if (speed <= 150)
            {
                speedStr = "fast";
                //Console.WriteLine("fast");
            }
            else if (speed <= 1000)
            {
                speedStr = "ultra fast";
                //Console.WriteLine("ultra fast");
            }
            else
            {
                speedStr = "extremely fast";
                //Console.WriteLine("extremely fast");
            }
            Console.WriteLine(speedStr);
        }
    }
}
