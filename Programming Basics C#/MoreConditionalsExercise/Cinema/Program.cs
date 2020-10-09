using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int collumns = int.Parse(Console.ReadLine());
            
            double ticketPrice=0;

            if (type=="Premiere")
            {
                ticketPrice = 12;            }
            else if (type=="Normal")
            {
                ticketPrice = 7.50;
            }
            else if (type=="Discount")
            {
                ticketPrice = 5;
            }
            int totalSeats = collumns * rows;
            double totalPrice = totalSeats * ticketPrice;
            Console.WriteLine($"{totalPrice:f2} leva");
        }
    }
}
