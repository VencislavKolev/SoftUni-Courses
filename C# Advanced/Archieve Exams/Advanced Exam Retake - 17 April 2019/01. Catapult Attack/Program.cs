
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _01._Catapult_Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] wallInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> walls = new Queue<int>(wallInput);
            Stack<int> rocks = new Stack<int>();

            for (int i = 1; i <= n; i++)
            {
                int[] rockInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
                if (walls.Count == 0)
                {
                    break;
                }
                foreach (var rock in rockInput)
                {
                    rocks.Push(rock);
                }
                if (i % 3 == 0)
                {
                    int newWallValue = int.Parse(Console.ReadLine());
                    walls.Enqueue(newWallValue);
                }
                while (walls.Any() && rocks.Any())
                {
                    int currWall = walls.Dequeue();
                    int currRock = rocks.Pop();

                    if (currRock > currWall)
                    {
                        rocks.Push(currRock - currWall);
                    }
                    else if (currWall > currRock)
                    {
                        walls.Enqueue(currWall - currRock);
                        //Пренареждане на опашката
                        //Изпълнява се ОТЛЯВО -> НАДЯСНО!
                        for (int j = 0; j < walls.Count - 1; j++)
                        {
                            //вади текущата първа колона и я слага най-отзад 
                            walls.Enqueue(walls.Dequeue());
                        }
                    }
                }
            }
            if (walls.Any())
            {
                Console.WriteLine($"Walls left: {string.Join(", ", walls)}");
            }
            else
            {
                Console.WriteLine($"Rocks left: {string.Join(", ", rocks)}");
            }
        }
    }
}
