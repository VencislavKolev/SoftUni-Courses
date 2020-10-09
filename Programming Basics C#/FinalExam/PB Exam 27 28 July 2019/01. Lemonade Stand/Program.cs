using System;

namespace _01._Lemonade_Stand
{
    class Program
    {
        static void Main(string[] args)
        {
            double lemons = double.Parse(Console.ReadLine());
            double sugar = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());

            double lemonJuiceInML = lemons * 980;
            double lemonade = lemonJuiceInML + water * 1000 + (sugar * 0.3);
            double soldLemonadeCups = Math.Floor(lemonade / 150);
            double moneyEarned = soldLemonadeCups * 1.20;

            Console.WriteLine($"All cups sold: {soldLemonadeCups}");
            Console.WriteLine($"Money earned: {moneyEarned:f2}");
        }
    }
}
