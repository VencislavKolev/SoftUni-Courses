using System;

namespace _05._Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            int tickets = int.Parse(Console.ReadLine());
            string one = "";
            string two = "";
            string three = "";
            char x = ' ';
            int num = 0;

            for (int i = 0; i < tickets; i++)
            {
                string value = Console.ReadLine();
                if (value.Length == 4)
                {
                    if (char.IsUpper(value[0]))
                    {
                        one = value[0].ToString();
                        two = value[1].ToString();
                        three = value[2].ToString();
                    }
                    else
                    {
                        one = value[3].ToString();
                        two = value[1].ToString();
                        three = value[2].ToString();
                    }
                }
                else if (value.Length == 5 || value.Length == 6)
                {
                    one = value[0].ToString();
                    x = value[1];
                    num = (int)x;
                }
                if (value.Length == 4)
                {
                    Console.WriteLine($"Seat decoded: {one}{two}{three}");
                }
                else
                {
                    Console.WriteLine($"Seat decoded: {one}{num}");
                }
            }
        }
    }
}
