using System;

namespace _01._Moon
{
    class Program
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());
            double distance = 384400 * 2;
            double time= Math.Ceiling(distance/speed);
            double totalTime = time + 3;
            double totalFuel = fuel * distance / 100;
            Console.WriteLine(totalTime);
            Console.WriteLine(totalFuel);
        }
    }
}
