using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isEven = false;
            while (!isEven)
            {
                if (number % 2 == 0)
                {
                    isEven = true;
                    break;
                }
                Console.WriteLine($"Please write an even number.");
                number = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The number is: {Math.Abs(number)}");
        }
    }
}
