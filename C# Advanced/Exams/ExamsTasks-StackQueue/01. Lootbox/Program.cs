using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> firstBox = new Queue<int>(firstInput);
            Stack<int> secondBox = new Stack<int>(secondInput);
            int sum = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstElement = firstBox.Peek();
                int secondElement = secondBox.Pop();
                int sumResult = firstElement + secondElement;
                bool isEven = sumResult % 2 == 0;
                if (isEven)
                {
                    sum += sumResult;
                    firstBox.Dequeue();
                }
                else
                {
                    firstBox.Enqueue(secondElement);
                }
            }
            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
