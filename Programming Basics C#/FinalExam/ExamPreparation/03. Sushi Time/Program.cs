using System;

namespace _03._Sushi_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushi = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int portions = int.Parse(Console.ReadLine());
            char order = char.Parse(Console.ReadLine());
            double price = 0;

            if (sushi == "sashimi")
            {
                switch (restaurant)
                {
                    case "Sushi Zone": price = 4.99 * portions; break;
                    case "Sushi Time": price = 5.49 * portions; break;
                    case "Sushi Bar": price = 5.25 * portions; break;
                    case "Asian Pub": price = 4.50 * portions; break;
                    default:
                        Console.WriteLine($"{restaurant} is invalid restaurant!");
                        return;
                }
            }
            else if (sushi == "maki")
            {
                switch (restaurant)
                {
                    case "Sushi Zone": price = 5.29 * portions; break;
                    case "Sushi Time": price = 4.69 * portions; break;
                    case "Sushi Bar": price = 5.55 * portions; break;
                    case "Asian Pub": price = 4.80 * portions; break;
                    default:
                        Console.WriteLine($"{restaurant} is invalid restaurant!");
                        return;
                }
            }
            else if (sushi == "uramaki")
            {
                switch (restaurant)
                {
                    case "Sushi Zone": price = 5.99 * portions; break;
                    case "Sushi Time": price = 4.49 * portions; break;
                    case "Sushi Bar": price = 6.25 * portions; break;
                    case "Asian Pub": price = 5.50 * portions; break;
                    default:
                        Console.WriteLine($"{restaurant} is invalid restaurant!");
                        return;
                }
            }
            else if (sushi == "temaki")
            {
                switch (restaurant)
                {
                    case "Sushi Zone": price = 4.29 * portions; break;
                    case "Sushi Time": price = 5.19 * portions; break;
                    case "Sushi Bar": price = 4.75 * portions; break;
                    case "Asian Pub": price = 5.50 * portions; break;
                    default:
                        Console.WriteLine($"{restaurant} is invalid restaurant!");
                        return;
                }
            }
            if (order == 'Y')
            {
                price *= 1.2;
                Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
            }
            else
            {
                Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
            }
        }
    }
}
