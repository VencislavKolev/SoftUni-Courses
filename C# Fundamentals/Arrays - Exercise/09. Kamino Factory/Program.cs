using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int seqLength = int.Parse(Console.ReadLine());

            int[] maxArray = new int[seqLength];
            int maxCount = 0;
            int maxIndex = 0;
            int maxSample = 1;
            int currentSample = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Clone them!")
                {
                    break;
                }
                int[] curArr = command.Split("!", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
                currentSample++;
                int bestCurrentCount = 0;
                int bestCurrentIndex = 0;
                int bestCurrSum = 0;
                for (int currIndex = 0; currIndex < curArr.Length; currIndex++)
                {
                    int currCount = 1;
                    int currElement = curArr[currIndex];
                    if (currElement == 0)
                    {
                        continue;
                    }
                    for (int index = currIndex + 1; index < curArr.Length; index++)
                    {
                        if (curArr[index] == 1)
                        {
                            currCount++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (currCount > bestCurrentCount)
                    {
                        bestCurrentCount = currCount;
                        bestCurrentIndex = currIndex;
                        bestCurrSum = curArr.Sum();
                    }
                }
                //after itterating the array
                if (bestCurrentCount > maxCount ||
                    (bestCurrentCount == maxCount && maxIndex > bestCurrentIndex) ||
                    maxArray.Sum() < bestCurrSum)
                {
                    maxIndex = bestCurrentIndex;
                    maxCount = bestCurrentCount;
                    maxArray = curArr;
                    maxSample = currentSample;
                }
            }
            Console.WriteLine($"Best DNA sample {maxSample} with sum: {maxArray.Sum()}.");
            Console.WriteLine(string.Join(" ", maxArray));
        }
    }
}
