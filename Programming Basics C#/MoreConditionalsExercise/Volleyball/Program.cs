using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsToHometown = int.Parse(Console.ReadLine());

            double gamesSaturdaySof = (48 - weekendsToHometown) * 3 / 4.0;
            double gamesSundayHometown = weekendsToHometown;
            double gamesOnHoliday = holidays * 2 / 3.0;
            double totalGames = gamesOnHoliday + gamesSaturdaySof + gamesSundayHometown;
            if (year=="leap")
            {
                totalGames *= 1.15;
            }
            Console.WriteLine($"{Math.Floor(totalGames)}");
        }
    }
}
