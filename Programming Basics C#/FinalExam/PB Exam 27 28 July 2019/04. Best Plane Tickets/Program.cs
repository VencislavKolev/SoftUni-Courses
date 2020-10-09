using System;

namespace _04._Best_Plane_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticket = Console.ReadLine();
            double priceEuro = double.Parse(Console.ReadLine());
            int landoverTime = int.Parse(Console.ReadLine());

            string bestTicket = "";
            int minLandoverTime = int.MaxValue;
            double finalPrice = 0;
            int hours = 0;
            int min = 0;

            while (ticket != "End")
            {
                if (landoverTime < minLandoverTime)
                {
                    minLandoverTime = landoverTime;
                    bestTicket = ticket;
                    finalPrice = priceEuro * 1.96;
                }
                ticket = Console.ReadLine();
                if (ticket == "End")
                {
                    break;
                }
                priceEuro = double.Parse(Console.ReadLine());
                landoverTime = int.Parse(Console.ReadLine());
            }
            hours = minLandoverTime / 60;
            min = minLandoverTime % 60;
            Console.WriteLine($" Ticket found for flight {bestTicket} costs {finalPrice:f2} leva with {hours}h {min}m stay");
        }

    }
}
