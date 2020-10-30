using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));
            Stack<int> casings = new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            int datura = 0; //40
            int cherry = 0; //60
            int smoke = 0; //120

            int decrease = 5;
            bool isFilled = false;
            while (effects.Count > 0 && casings.Count > 0)
            {
                int currEffect = effects.Peek();
                int currCasing = casings.Pop();
                int sum = currEffect + currCasing;

                bool isBomb = false;
                if (sum == 40)
                {
                    datura++;
                    isBomb = true;
                }
                else if (sum == 60)
                {
                    cherry++;
                    isBomb = true;
                }
                else if (sum == 120)
                {
                    smoke++;
                    isBomb = true;
                }
                if (isBomb)
                {
                    effects.Dequeue();
                }
                else if (!isBomb)
                {
                    if (currCasing - decrease >= 0)
                    {
                        casings.Push(currCasing - decrease);
                    }
                }
                if (datura >= 3 && cherry >= 3 && smoke >= 3)
                {
                    isFilled = true;
                    break;
                }
            }
            if (isFilled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (effects.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (casings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smoke}");
        }
    }
}
