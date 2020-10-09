using System;

namespace PipesINPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int PoolVolume = int.Parse(Console.ReadLine());
            int Pipe1Debit = int.Parse(Console.ReadLine());
            int Pipe2Debit = int.Parse(Console.ReadLine());
            double missingHours = double.Parse(Console.ReadLine());
            //
            double LitersFilled = (Pipe1Debit + Pipe2Debit) * missingHours;
            double percentageFilled = (LitersFilled / PoolVolume) * 100;
            double pipe1Percentage = ((Pipe1Debit * missingHours) / LitersFilled) * 100;
            double pipe2Percentage = ((Pipe2Debit * missingHours) / LitersFilled) * 100;


            if (LitersFilled<=PoolVolume)
            {
                Console.WriteLine($"The pool is {percentageFilled:f2}% full. Pipe 1: {pipe1Percentage:f2}%. Pipe 2: {pipe2Percentage:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {missingHours} hours the pool overflows with {LitersFilled-PoolVolume} liters.");
            }

        }
    }
}
