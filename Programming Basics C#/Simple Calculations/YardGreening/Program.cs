using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double i = double.Parse(Console.ReadLine());
            double Price = i * 7.61;
            double discount = 0.18 * Price;
            double finalPrice = Price - discount;
            Console.WriteLine($"The final price is: {finalPrice:f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");

        }
    }
}
