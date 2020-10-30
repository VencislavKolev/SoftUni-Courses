using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            //form first -> Queue
            List<int> lilies = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            List<int> roses = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            //from last -> Stack

            Queue<int> rosesQueue = new Queue<int>(roses);
            Stack<int> liliesStack = new Stack<int>(lilies);
            int totalWreaths = 0;
            int storedFlowersSum = 0;
            while (rosesQueue.Count > 0 && liliesStack.Count > 0)
            {
                int currLilie = liliesStack.Pop();
                int currRose = rosesQueue.Dequeue();
                int currSum = currLilie + currRose;
                if (currSum == 15)
                {
                    totalWreaths++;
                }
                else if (currSum > 15)
                {
                    while (currSum > 15)
                    {
                        currLilie -= 2;
                        currSum = currLilie + currRose;
                    }
                    if (currSum == 15)
                    {
                        totalWreaths++;
                    }
                    else
                    {
                        storedFlowersSum += currSum;
                    }
                }
                else
                {
                    storedFlowersSum += currSum;
                }
            }
            if (storedFlowersSum >= 15)
            {
                int newWreaths = storedFlowersSum / 15;
                totalWreaths += newWreaths;
            }
            if (totalWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {totalWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - totalWreaths} wreaths more!");
            }
        }
    }
}
