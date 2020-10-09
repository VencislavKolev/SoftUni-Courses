using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int counter = 1;
            int maxNumber = int.MinValue;
            while (counter <= numbers)
            {
                int input = int.Parse(Console.ReadLine());
                counter++;
                if (input>maxNumber)
                {
                    maxNumber = input;
                }
            }
            Console.WriteLine(maxNumber);
        }
    }
}
