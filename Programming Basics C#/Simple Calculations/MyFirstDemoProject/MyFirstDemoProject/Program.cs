using System;

namespace MyFirstDemoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your first number:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your first number:");
            int b = int.Parse(Console.ReadLine());
            int area = a * b;
            Console.WriteLine("Result: " + area);

        }
    }
}
