using System;

namespace Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string weekDay = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (weekDay == "Saturday" || weekDay == "Sunday")
            {
                switch (fruit)
                {
                    case "banana": Console.WriteLine($"{quantity * 2.70:f2}"); break;
                    case "apple": Console.WriteLine($"{quantity * 1.25:f2}"); break;
                    case "orange": Console.WriteLine($"{quantity * 0.9:f2}"); break;
                    case "grapefruit": Console.WriteLine($"{quantity * 1.60:f2}"); break;
                    case "kiwi": Console.WriteLine($"{quantity * 3.00:f2}"); break;
                    case "pineapple": Console.WriteLine($"{quantity * 5.60:f2}"); break;
                    case "grapes": Console.WriteLine($"{quantity * 4.20:f2}"); break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (weekDay == "Monday" || weekDay == "Tuesday" || weekDay == "Wednesday" || weekDay == "Thursday" || weekDay == "Friday")
            {
                switch (fruit)
                {
                    case "banana": Console.WriteLine($"{quantity * 2.50:f2}"); break;
                    case "apple": Console.WriteLine($"{quantity * 1.2:f2}"); break;
                    case "orange": Console.WriteLine($"{quantity * 0.85:f2}"); break;
                    case "grapefruit": Console.WriteLine($"{quantity * 1.45:f2}"); break;
                    case "kiwi": Console.WriteLine($"{quantity * 2.70:f2}"); break;
                    case "pineapple": Console.WriteLine($"{quantity * 5.50:f2}"); break;
                    case "grapes": Console.WriteLine($"{quantity * 3.85:f2}"); break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}