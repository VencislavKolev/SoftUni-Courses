using System;

namespace _04._Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengers = int.Parse(Console.ReadLine());
            int busStops = int.Parse(Console.ReadLine());
            int input = 0;
            int output = 0;
            for (int i = 1; i <= busStops; i++)
            {
                output = int.Parse(Console.ReadLine());
                input = int.Parse(Console.ReadLine());
                
                if (i%2==0) //четна
                {
                    output += 2;
                    passengers += input - output;
                }
                else //нечетна
                {
                    input += 2;
                    passengers += input - output;
                }
            }
            Console.WriteLine($"The final number of passengers is : {passengers}");
        }
    }
}
