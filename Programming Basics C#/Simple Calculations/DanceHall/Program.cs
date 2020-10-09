using System;

namespace DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double sideWardrobe=double.Parse(Console.ReadLine());

            double totalspace = (length * 100) * (width * 100);
            double seat = totalspace / 10;
            double wardrobeSpace = ((sideWardrobe*100) * (sideWardrobe*100));

            double freeSpace = totalspace-(seat+wardrobeSpace);
            double dancers =Math.Floor(freeSpace / (40+7000));
           
            Console.WriteLine($"{dancers}");
            
        }
    }
}
