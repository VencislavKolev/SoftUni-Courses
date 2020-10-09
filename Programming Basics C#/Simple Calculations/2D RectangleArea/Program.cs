using System;

namespace _2D_RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double lenght = Math.Abs(x1 - x2);
            double width = Math.Abs(y1 - y2);

            double perimeter = 2 * (lenght + width);
            double area = lenght * width;

            Console.WriteLine($"Пермитърът е: {perimeter:f2}" );
            Console.WriteLine($"Площта е: {area:f2}" );



        }
    }
}
