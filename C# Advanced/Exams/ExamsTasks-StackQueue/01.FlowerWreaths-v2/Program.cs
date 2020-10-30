using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            // 5wreaths
            //1 wreath=15 flowers

            //last lile
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));
            //first rose
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            int wreaths = 0;
            int leftFlowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lilie = lilies.Pop();
                int rose = roses.Peek();
                int sum = lilie + rose;

                if (sum == 15)
                {
                    wreaths++;
                    roses.Dequeue();
                }
                else if (sum > 15)
                {
                    if (lilie - 2 >= 0)
                    {
                        lilies.Push(lilie - 2);
                    }
                }
                else if (sum < 15)
                {
                    leftFlowers += sum;
                    roses.Dequeue();
                }
            }
            if (leftFlowers >= 15)
            {
                int extraWreaths = leftFlowers / 15;
                wreaths += extraWreaths;
            }
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
