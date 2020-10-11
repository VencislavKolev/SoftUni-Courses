using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] lockSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            Queue<int> locks = new Queue<int>(lockSize);
            Stack<int> bullets = new Stack<int>(bulletSize);
            int barrelCount = 0;
            int firedBullets = 0;
            while (bullets.Any() && locks.Any())
            {
                int currBulletSize = bullets.Peek();
                int currLockSize = locks.Peek();
                if (currBulletSize <= currLockSize)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                bullets.Pop();
                barrelCount++;
                firedBullets++;
                if (barrelCount == gunBarrelSize && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    barrelCount = 0;
                }
            }
            if (locks.Count == 0 && bullets.Count >= 0)
            {
                int moneyEarned = valueOfIntelligence - (firedBullets * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
