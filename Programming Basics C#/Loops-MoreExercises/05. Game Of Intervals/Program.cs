using System;

namespace _05._Game_Of_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int numRounds = int.Parse(Console.ReadLine());
            double result = 0;
            int invalidNumbers = 0;
            int zeroTo9 = 0;
            int tenTo19 = 0;
            int twentyTo29 = 0;
            int thirtyTo39 = 0;
            int FortyTo50 = 0;

            for (int i = 1; i <= numRounds; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0 || number > 50)
                {
                    invalidNumbers++;
                    result /= 2;
                }
                else if (number < 10)
                {
                    result += 0.2 * number;
                    zeroTo9++;
                }
                else if (number < 20)
                {
                    result += 0.3 * number;
                    tenTo19++;
                }
                else if (number < 30)
                {
                    result += 0.4 * number;
                    twentyTo29++;
                }
                else if (number < 40)
                {
                    result += 50;
                    thirtyTo39++;
                }
                else if (number <=50)
                {
                    result += 100;
                    FortyTo50++;
                }
            }
            Console.WriteLine($"{result:f2}");
            Console.WriteLine($"From 0 to 9: {zeroTo9*1.0/numRounds*100:f2}%");
            Console.WriteLine($"From 10 to 19: {tenTo19*1.0/numRounds*100:f2}%");
            Console.WriteLine($"From 20 to 29: {twentyTo29*1.0/numRounds*100:f2}%");
            Console.WriteLine($"From 30 to 39: {thirtyTo39*1.0/numRounds*100:f2}%");
            Console.WriteLine($"From 40 to 50: {FortyTo50*1.0/numRounds*100:f2}%");
            Console.WriteLine($"Invalid numbers: {invalidNumbers*1.0/numRounds*100:f2}%");
        }
    }
}
