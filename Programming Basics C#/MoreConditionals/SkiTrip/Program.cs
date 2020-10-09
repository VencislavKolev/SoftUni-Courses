using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string feedback = Console.ReadLine();
            int nights = days - 1;
            double Sum = 0;
            

            if (room=="room for one person")
            {
                Sum = nights * 18;
            }
            else if (room=="apartment")
            {
                if (days<10)
                {
                    Sum = nights * 25 * 0.7;
                }
                else if (days>=10 && days<=15)
                {
                    Sum = nights * 25 * 0.65;
                }
                else if (days>15)
                {
                    Sum = nights * 25 * 0.5;
                }
            }
            else if (room == "president apartment")
            {
                if (days < 10)
                {
                    Sum = nights * 35 * 0.9;
                }
                else if (days >= 10 && days <= 15)
                {
                    Sum = nights * 35 * 0.85;
                }
                else if (days > 15)
                {
                    Sum = nights * 35 * 0.8;
                }
            }
            if (feedback=="positive")
            {
                Sum *= 1.25;
            }
            else
            {
                Sum *= 0.9;
            } 
            Console.WriteLine($"{Sum:f2}");
        }
       
    }
}
