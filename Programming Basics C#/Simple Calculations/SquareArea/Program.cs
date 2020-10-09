using System;

namespace SquareArea
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter square : ");
            var side = double.Parse(Console.ReadLine());
            var area = side * side;
            Console.WriteLine(area);
        }
    }
}
