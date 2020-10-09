using System;

namespace _07._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int totalStudent = 0;
            int totalStandard = 0;
            int totalKid = 0;
            while (filmName != "Finish") //четем филм,който НЕ е Finish
            {
                int studentCounter = 0;
                int standardCounter = 0;
                int kidCounter = 0;

                int freeSeats = int.Parse(Console.ReadLine()); //свободни места в залата
                for (int i = 1; i <= freeSeats; i++)
                {
                    string ticketType = Console.ReadLine(); //вид на билета
                    if (ticketType == "student")
                    {
                        studentCounter++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardCounter++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidCounter++;
                    }
                    else if (ticketType == "End")
                    {
                        break;
                    }
                }
                Console.WriteLine($"{filmName} - {(studentCounter + standardCounter + kidCounter) * 1.0 / freeSeats * 100:f2}% full.");
                //Колко % от местата в залата са заети
                totalStandard += standardCounter;
                totalStudent += studentCounter;           //прибавяме типа билети от конкретния филм към общия брой на типа билети за всички филми 
                totalKid += kidCounter;

                filmName = Console.ReadLine();
            }
            int totalTickets = totalKid + totalStandard + totalStudent;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{totalStudent * 1.0 / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{totalStandard * 1.0 / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{totalKid * 1.0 / totalTickets * 100:f2}% kids tickets.");
        }
    }
}
