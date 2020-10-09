using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfDeposits = int.Parse(Console.ReadLine());
            double sum = 0;
            int counter = 1;
            while (counter <= numOfDeposits)
            {
                double depositSum = double.Parse(Console.ReadLine());
                if (depositSum <= 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {depositSum:f2}" );
                counter++;
                sum += depositSum;
            }
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
