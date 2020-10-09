using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            var volume = lenght * width * height/1000;
            var loses = percentage * volume / 100;
            var liters = volume - loses;
            Console.WriteLine($"{liters:f3}");
        }
    }
}
