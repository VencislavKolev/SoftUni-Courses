using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int counter = 1;
            int minNumber = int.MaxValue;
            while (counter <= numbers)
            {
                int input = int.Parse(Console.ReadLine());
                counter++;
                if (input < minNumber)
                {
                    minNumber = input;
                }
            }
            Console.WriteLine(minNumber);
        }
    }
}
