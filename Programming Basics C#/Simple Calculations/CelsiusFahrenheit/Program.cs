using System;

namespace CelsiusFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Моля въведи число в Целзии: ");
            double celsius = double.Parse(Console.ReadLine());
            Console.Write("Моля въведи число във Фаренхайт: ");
            double fahrenheit = double.Parse(Console.ReadLine());

            double formulaCtoF = celsius * 1.8 + 32;
            double formulaFtoC = (fahrenheit - 32) / 1.8;
            Console.WriteLine("Градуси фаренхайт= " + Math.Round(formulaCtoF, 2));
            Console.WriteLine("Градуси целзии= " + Math.Round(formulaFtoC, 2));

        }
    }
}
