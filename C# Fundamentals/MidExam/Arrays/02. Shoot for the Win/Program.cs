using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToArray();
            string input = "";
            int shotsCount = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                int indexToShoot = int.Parse(input);
                if (indexToShoot >= 0 && indexToShoot < targets.Length)
                {
                    if (targets[indexToShoot] == -1)
                    {
                        continue;
                    }
                    int targetValue = targets[indexToShoot];
                    targets[indexToShoot] = -1;
                    shotsCount++;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] == -1)
                        {
                            continue;
                        }
                        if (targets[i] > targetValue)
                        {
                            targets[i] -= targetValue;
                        }
                        else
                        {
                            targets[i] += targetValue;
                        }
                    }
                }
            }
            Console.WriteLine($"Shot targets: {shotsCount} -> " +
                $"{string.Join(" ", targets)}");
        }
    }
}
