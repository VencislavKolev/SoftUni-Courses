using System;

namespace SchoolRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double lenghtCM = lenght * 100;
            double widthCM = width * 100;

            //int cols = ((int)widthCM - 100) / 70;
            //int rows = (int)lenghtCM / 120;

            double cols = Math.Truncate((widthCM - 100) / 70);
            double rows = Math.Truncate(lenghtCM / 120);
            double seats = cols * rows - 3;
           
            Console.WriteLine($"Налични работни места: {seats}");



        }
    }
}
