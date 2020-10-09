using System;

namespace _03._Travel_Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string packageType = Console.ReadLine();
            string vip = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }
            double price = 0;
            if (city == "Bansko" || city == "Borovets")
            {
                switch (packageType)
                {
                    case "noEquipment":
                        price = 80 * days;
                        if (days > 7)
                        {
                            price -= price / days * 1.0;
                        }
                        if (vip == "yes")
                        {
                            price *= 0.95;
                        }

                        break;
                    case "withEquipment":
                        price = 100 * days;
                        if (days > 7)
                        {
                            price -= price / days * 1.0;
                        }
                        if (vip == "yes")
                        {
                            price *= 0.90;
                        }

                        break;
                }
            }
            else if (city == "Varna" || city == "Burgas")
            {
                switch (packageType)
                {
                    case "noBreakfast":
                        price = 100 * days;
                        if (days > 7)
                        {
                            price -= price / days * 1.0;
                        }
                        if (vip == "yes")
                        {
                            price *= 0.93;
                        }
                        break;
                    case "withBreakfast":
                        price = 130 * days;
                        if (days > 7)
                        {
                            price -= price / days * 1.0;
                        }
                        if (vip == "yes")
                        {
                            price *= 0.88;
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            Console.WriteLine($"The price is {price:f2}lv! Have a nice time!");
        }
    }
}
