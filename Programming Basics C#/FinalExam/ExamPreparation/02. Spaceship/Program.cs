using System;

namespace _02._Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double averageHeight = double.Parse(Console.ReadLine());
            double spaceshipVolume = width * lenght * height;
            double room = 2 * 2 * (averageHeight + 0.4);
            double totalRooms = spaceshipVolume / room;
            if (totalRooms>10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
            else if (totalRooms<3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine($"The spacecraft holds {Math.Floor(totalRooms)} astronauts.");
            }
            
        }
    }
}
