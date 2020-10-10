using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;


            if (groupType == "Students")
            {
                if (day == "Friday")
                {
                    price = number * 8.45;
                }
                else if (day == "Saturday")
                {
                    price = number * 9.8;
                }
                else if (day == "Sunday")
                {
                    price = number * 10.46;
                }
                if (number >= 30)
                {
                    price *= 0.85;
                }
            }

            else if (groupType == "Business")
            {
                if (day == "Friday")
                {
                    price = number * 10.9;
                }
                else if (day == "Saturday")
                {
                    price = number * 15.6;
                }
                else if (day == "Sunday")
                {
                    price = number * 16;
                }
                if (number >= 100)
                {
                    if (day == "Friday")
                    {
                        price = (number - 10) * 10.9;
                    }
                    else if (day == "Saturday")
                    {
                        price = (number - 10) * 15.6;
                    }
                    else if (day == "Sunday")
                    {
                        price = (number - 10) * 16;
                    }
                }
            }

            else if (groupType == "Regular")
            {
                if (day == "Friday")
                {
                    price = number * 15;
                }
                else if (day == "Saturday")
                {
                    price = number * 20;
                }
                else if (day == "Sunday")
                {
                    price = number * 22.5;
                }
                if (number >= 10 && number <= 20)
                {
                    price *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
