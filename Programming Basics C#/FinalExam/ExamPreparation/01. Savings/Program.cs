using System;

namespace _01._Savings
{
    class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine());
            double souveniers = double.Parse(Console.ReadLine());
            double hotel = double.Parse(Console.ReadLine());
            double gasMoney = 420 * 1.0 / 100 * 7 * 1.85;
            double foodAndSouveniers = food * 3 + souveniers * 3;
            double day1 = hotel * 0.9;
            double day2 = hotel * 0.85;
            double day3 = hotel * 0.80;
            double totalMoney = gasMoney + foodAndSouveniers + day1 + day2 + day3;
            Console.WriteLine($"Money needed: {totalMoney:f2}");
        }
    }
}
