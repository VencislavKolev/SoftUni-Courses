using System;

namespace TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string DayNight = Console.ReadLine();
            double taxiPrice=0;
            double busPrice = 0.09 * kilometers;
            double trainPrice = 0.06 * kilometers;
            if (DayNight=="day")
            {
              taxiPrice = 0.7 + 0.79 * kilometers;

            }
            else if (DayNight=="night")
            {
               taxiPrice = 0.7 + 0.9 * kilometers;
            }
            if (kilometers<20)
            {
                Console.WriteLine($"{taxiPrice:f2}");
            }
            else if (kilometers>=100)
            {
                Console.WriteLine($"{trainPrice:f2}");
            }
            else
            {
                Console.WriteLine($"{busPrice:f2} ");
            }
        }
    }
}
