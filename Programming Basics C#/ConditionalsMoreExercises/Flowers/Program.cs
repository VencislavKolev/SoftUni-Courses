using System;

namespace Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int magnoliq = int.Parse(Console.ReadLine());
            int zumbul = int.Parse(Console.ReadLine());
            int rose = int.Parse(Console.ReadLine());
            int cactus = int.Parse(Console.ReadLine());
            double present = double.Parse(Console.ReadLine());

            double totalMoney = magnoliq * 3.25 + zumbul * 4 +
                rose * 3.5 + cactus * 8;
            double tax = totalMoney * 0.05;
            double MoneyLeft = totalMoney - tax;

            if (MoneyLeft>=present)
            {
                Console.WriteLine($"She is left with {Math.Floor(MoneyLeft-present)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(present-MoneyLeft)} leva.");
            }
        }


    }
}
