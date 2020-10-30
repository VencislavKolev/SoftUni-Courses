using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            //form first -> Queue
            List<int> effects = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            List<int> casings = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            //from last -> Stack
            Queue<int> bombEffects = new Queue<int>(effects);
            Stack<int> bombCasings = new Stack<int>(casings);
            // 3 of each
            int daturaBombValue = 40;
            int cherryBombValue = 60;
            int smokeDecoyBombValue = 120;

            int datureBombsCount = 0;
            int cherryBombCount = 0;
            int smokeDecoyBombCount = 0;
            bool isFull = false;

            while (bombCasings.Count > 0 && bombEffects.Count > 0 && isFull == false)
            {
                int currEffect = bombEffects.Peek();
                int currCasing = bombCasings.Pop();
                int currSum = currEffect + currCasing;
                if (currSum == daturaBombValue)
                {
                    datureBombsCount++;
                }
                else if (currSum == cherryBombValue)
                {
                    cherryBombCount++;
                }
                else if (currSum == smokeDecoyBombValue)
                {
                    smokeDecoyBombCount++;
                }
                else
                {
                    if (currCasing - 5 >= 0)
                    {
                        bombCasings.Push(currCasing - 5);
                        continue;
                    }
                }
                bombEffects.Dequeue();
                isFull = CheckIfPouchIsFull(datureBombsCount, cherryBombCount, smokeDecoyBombCount);
                //if (isFull)
                //{
                //    break;
                //}
            }
            string firstOutputMessage;
            if (isFull)
            {
                firstOutputMessage = "Bene! You have successfully filled the bomb pouch!";
            }
            else
            {
                firstOutputMessage = "You don't have enough materials to fill the bomb pouch.";
            }
            Console.WriteLine(firstOutputMessage);

            string secondOutputMessage;
            if (bombEffects.Any())
            {
                secondOutputMessage = $"Bomb Effects: {string.Join(", ", bombEffects)}";
            }
            else
            {
                secondOutputMessage = "Bomb Effects: empty";
            }
            Console.WriteLine(secondOutputMessage);

            string thirdOutputMessage;
            if (bombCasings.Any())
            {
                thirdOutputMessage = $"Bomb Casings: {string.Join(", ", bombCasings)}";
            }
            else
            {
                thirdOutputMessage = "Bomb Casings: empty";
            }
            Console.WriteLine(thirdOutputMessage);

            Console.WriteLine($"Cherry Bombs: {cherryBombCount}");
            Console.WriteLine($"Datura Bombs: {datureBombsCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombCount}");
        }
        public static bool CheckIfPouchIsFull(int datureBombsCount, int cherryBombCount, int smokeDecoyBombCount)
        {
            return datureBombsCount >= 3 && cherryBombCount >= 3 && smokeDecoyBombCount >= 3;
        }
    }
}
