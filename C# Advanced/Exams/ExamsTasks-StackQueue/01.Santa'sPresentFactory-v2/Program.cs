using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Santa_sPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> materials = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            Queue<int> magicLevels = new Queue<int>(Console.ReadLine()
              .Split()
              .Select(int.Parse));

            int doll = 0;
            int woodenTrain = 0;
            int teddyBear = 0;
            int bicycle = 0;

            while (materials.Count > 0 && magicLevels.Count > 0)
            {
                int material = materials.Peek();
                int magic = magicLevels.Peek();
                if (material == 0 || magic == 0)
                {
                    if (material == 0)
                    {
                        materials.Pop();
                    }
                    if (magic == 0)
                    {
                        magicLevels.Dequeue();
                    }
                    continue;
                }

                int result = material * magic;

                bool isDoll = false;
                if (result == 150)
                {
                    doll++;
                    isDoll = true;
                }
                else if (result == 250)
                {
                    woodenTrain++;
                    isDoll = true;
                }
                else if (result == 300)
                {
                    teddyBear++;
                    isDoll = true;
                }
                else if (result == 400)
                {
                    bicycle++;
                    isDoll = true;
                }
                else if (result < 0)
                {
                    int sum = material + magic;
                    materials.Pop();
                    magicLevels.Dequeue();

                    materials.Push(sum);
                }
                else if (result > 0)
                {
                    magicLevels.Dequeue();
                    materials.Pop();
                    materials.Push(material + 15);
                }
                if (isDoll)
                {
                    materials.Pop();
                    magicLevels.Dequeue();
                }
            }

            bool dollTrainCombo = doll > 0 && woodenTrain > 0;
            bool bearBicycleCombo = teddyBear > 0 && bicycle > 0;

            if (dollTrainCombo || bearBicycleCombo)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
            if (materials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }
            if (magicLevels.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicLevels)}");
            }
            if (bicycle > 0)
            {
                Console.WriteLine($"Bicycle: {bicycle}");
            }
            if (doll > 0)
            {
                Console.WriteLine($"Doll: {doll}");
            }
            if (teddyBear > 0)
            {
                Console.WriteLine($"Teddy bear: {teddyBear}");
            }
            if (woodenTrain > 0)
            {
                Console.WriteLine($"Wooden train: {woodenTrain}");
            }

        }
    }
}
