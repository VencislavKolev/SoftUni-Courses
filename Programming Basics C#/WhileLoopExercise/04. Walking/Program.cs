using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int stepSum = 0;
            int inputAsNum = 0;
            while (input != "Going home")
            {
                inputAsNum = int.Parse(input);
                stepSum += inputAsNum;
                if (stepSum >= 10000)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Going home")
            {
                input = Console.ReadLine();
                inputAsNum = int.Parse(input);
                stepSum += inputAsNum;
            }
            if (stepSum < 10000)
            {
                Console.WriteLine($"{10000 - stepSum} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
            }

        }
    }
}
