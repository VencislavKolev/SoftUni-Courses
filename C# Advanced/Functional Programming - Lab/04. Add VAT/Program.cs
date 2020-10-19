using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVat = num => num * 1.2;
            Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(addVat) // x => x * 1.2
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
