using System;

namespace _03._Luggage_Tax
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double depth = double.Parse(Console.ReadLine());
            string priorityTicket = Console.ReadLine();
            double volume = width * height * depth;
            int tax = 0;
            if (priorityTicket == "true")
            {
                if (volume <= 100)
                {
                    tax = 0;
                }
                else if (volume <= 200)
                {
                    tax = 10;
                }
                else if (volume <= 300)
                {
                    tax = 20;
                }
            }
            else if (priorityTicket == "false")
            {
                if (volume < 50)
                {
                    tax = 0;
                }
                else if (volume >= 50 && volume <= 100)
                {
                    tax = 25;
                }
                else if (volume <= 200)
                {
                    tax = 50;
                }
                else if (volume <= 300)
                {
                    tax = 100;
                }

            }
            Console.WriteLine($"Luggage tax: {tax:f2}");
        }
    }
}
