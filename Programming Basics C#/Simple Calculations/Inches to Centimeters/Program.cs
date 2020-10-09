using System;

namespace SquareArea
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Въведи число в инчове:");   
            double inches = double.Parse(Console.ReadLine());
            double centimeteres = inches * 2.54;
            Console.WriteLine(centimeteres);
        }
    }
}
