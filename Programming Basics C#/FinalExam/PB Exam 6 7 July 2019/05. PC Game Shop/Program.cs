using System;

namespace _05._PC_Game_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int soldGames = int.Parse(Console.ReadLine());
            int hearthStoneCount = 0;
            int forniteCount = 0;
            int overwatchCount = 0;
            int othersCount = 0;

            for (int i = 0; i < soldGames; i++)
            {
                string game = Console.ReadLine();
                switch (game)
                {
                    case "Hearthstone": hearthStoneCount++; break;
                    case "Fornite": forniteCount++; break;
                    case "Overwatch": overwatchCount++; break;
                    default: othersCount++; break;
                }
            }
            Console.WriteLine($"Hearthstone - {hearthStoneCount * 1.0 / soldGames * 100:f2}%");
            Console.WriteLine($"Fornite - {forniteCount * 1.0 / soldGames * 100:f2}%");
            Console.WriteLine($"Overwatch - {overwatchCount * 1.0 / soldGames * 100:f2}%");
            Console.WriteLine($"Others - {othersCount * 1.0 / soldGames * 100:f2}%");
        }
    }
}
