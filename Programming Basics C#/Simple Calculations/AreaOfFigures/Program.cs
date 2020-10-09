using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string shape = Console.ReadLine();
           
            if (shape=="square")
            {
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a*a:f3}");
            }
            else if (shape=="rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a*b:f3}");
            }
            else if (shape=="circle")
            {
                double r = double.Parse(Console.ReadLine());
                Console.WriteLine($"{Math.PI*r*r:f3}");
            }
            else if (shape=="triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a*h/2:f3}");
            }
        }
    }
}
