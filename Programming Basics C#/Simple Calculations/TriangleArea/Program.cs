using System;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Въведи страната а:");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Въведи височината h:");
            double h = double.Parse(Console.ReadLine());
            double area = a * h / 2;
            Console.WriteLine("Лицето на триъгълникът е: " + Math.Round(area, 2));
            Console.WriteLine($"Лицето на триъгълникът е: {area:f2} ");
        }
    }
}
