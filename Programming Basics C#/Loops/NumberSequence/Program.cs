using System;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int MaxNumber = int.MinValue;
            int MinNumber = int.MaxValue;
            for (int i = 1; i <= numbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber<MinNumber)
                {
                    MinNumber = currentNumber;
                }
                if (currentNumber>MaxNumber)
                {
                    MaxNumber = currentNumber;
                }
            }
            Console.WriteLine($"Max number: {MaxNumber}");
            Console.WriteLine($"Min number: {MinNumber}");
        }
    }
}
