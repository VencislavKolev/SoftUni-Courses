using System;

namespace _02._Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayRes = int.Parse(Console.ReadLine());
            int monthRes = int.Parse(Console.ReadLine());
            int dayArrival = int.Parse(Console.ReadLine());
            int monthArrival = int.Parse(Console.ReadLine());
            int dayCheckout = int.Parse(Console.ReadLine());
            int monthCheckout = int.Parse(Console.ReadLine());

            double doubleRoom = 30;

            if (dayArrival - dayRes >= 10)
            {
                doubleRoom = 25;
            }
            else if (monthArrival - monthRes >= 1)
            {
                doubleRoom = 25 * 0.8;
            }
            double totalPrice = (dayCheckout - dayArrival) * doubleRoom;
            Console.WriteLine($"Your stay from {dayArrival}/{monthArrival} to" +
                $" {dayCheckout}/{monthCheckout} will cost {totalPrice:f2}");

        }
    }
}
