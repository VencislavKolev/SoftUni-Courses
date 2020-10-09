using System;

namespace _02._Summer_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            double beachTowelPrice = double.Parse(Console.ReadLine());
            int discountPercentage = int.Parse(Console.ReadLine());

            double umbrella = beachTowelPrice * 2 / 3;
            double flipFlops = umbrella * 0.75;
            double beachBag = (beachTowelPrice + flipFlops) * 1 / 3;

            double totalPrice = (beachTowelPrice + umbrella + flipFlops + beachBag);
            double discount = discountPercentage * 1.0 / 100;
            double PriceAfterDiscount = totalPrice - (totalPrice * discount);
            if (budget>=PriceAfterDiscount)
            {
                Console.WriteLine($"Annie's sum is {PriceAfterDiscount:f2} lv. She has {budget-PriceAfterDiscount:f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {PriceAfterDiscount:f2} lv. She needs {Math.Abs(PriceAfterDiscount-budget):f2} lv. more.");
            }
        }
    }
}
