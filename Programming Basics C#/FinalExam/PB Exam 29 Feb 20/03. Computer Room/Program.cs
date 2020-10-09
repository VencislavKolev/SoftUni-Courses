using System;

namespace _03._Computer_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hoursSpent = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string partOfDay = Console.ReadLine();
            double pricePerPersonForHours = 0;

            if (month == "march" || month == "april" || month == "may")
            {
                switch (partOfDay)
                {
                    case "day": pricePerPersonForHours = 10.5; break;
                    case "night": pricePerPersonForHours = 8.4; break;
                }
                if (people>=4)
                {
                    pricePerPersonForHours *= 0.90;
                }
                if (hoursSpent>=5)
                {
                    pricePerPersonForHours *= 0.5;
                }
            }
            else if (month == "june" || month == "july" || month == "august")
            {
                switch (partOfDay)
                {
                    case "day": pricePerPersonForHours = 12.6 ; break;
                    case "night": pricePerPersonForHours = 10.2 ; break;
                }
                if (people >= 4)
                {
                    pricePerPersonForHours *= 0.90;
                }
                if (hoursSpent >= 5)
                {
                    pricePerPersonForHours *= 0.5;
                }
            }
            double totalPrice = pricePerPersonForHours * hoursSpent * people;
            Console.WriteLine($"Price per person for one hour: {pricePerPersonForHours:f2}"); 
            Console.WriteLine($"Total cost of the visit: {totalPrice:f2}");
        }
    }
}
