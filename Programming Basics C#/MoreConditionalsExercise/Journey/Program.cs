using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string housing = "";
            string location = "";
            double moneySpent =0;

            if (budget<=100)
            {
                location = "Bulgaria";
                switch (season)
                {
                    case "summer":moneySpent = budget * 0.3;
                        housing = "Camp"; break;
                    case "winter":moneySpent = budget * 0.7;
                        housing = "Hotel"; break;
                }
            }
            else if (budget<=1000)
            {
                location = "Balkans";
                switch (season)
                {
                    case "summer":
                        moneySpent = budget * 0.4;
                        housing = "Camp"; break;
                    case "winter":
                        moneySpent = budget * 0.8;
                        housing = "Hotel"; break;
                }
            }
            else if (budget>1000 && (season=="summer" || season=="winter"))
            {
                location = "Europe";
                moneySpent = budget * 0.9;
                housing = "Hotel";
            }
            Console.WriteLine($"Somewhere in {location}");
            Console.WriteLine($"{housing} - {moneySpent:f2}");
        }
    }
}
