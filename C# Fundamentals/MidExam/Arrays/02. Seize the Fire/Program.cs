using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split('#').ToArray();
            int availableWater = int.Parse(Console.ReadLine());
            double effort = 0;
            double totalFire = 0;
            List<int> putOutCells = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                string[] splitted = arr[i].Split(" = ").ToArray();
                string fireType = splitted[0];
                int valueOfCell = int.Parse(splitted[1]);
                if (fireType == "High" && valueOfCell >= 81 && valueOfCell <= 125
                    && availableWater >= valueOfCell)
                {
                    putOutCells.Add(valueOfCell);
                    effort += valueOfCell * 0.25;
                    totalFire += valueOfCell;
                    availableWater -= valueOfCell;
                }
                else if (fireType == "Medium" && valueOfCell >= 51 && valueOfCell <= 80
                    && availableWater >= valueOfCell)
                {
                    putOutCells.Add(valueOfCell);
                    effort += valueOfCell * 0.25;
                    totalFire += valueOfCell;
                    availableWater -= valueOfCell;
                }
                else if (fireType == "Low" && valueOfCell >= 1 && valueOfCell <= 50
                    && availableWater >= valueOfCell)
                {
                    putOutCells.Add(valueOfCell);
                    effort += valueOfCell * 0.25;
                    totalFire += valueOfCell;
                    availableWater -= valueOfCell;
                }
            }
            Console.WriteLine("Cells:");
            foreach (var cell in putOutCells)
            {
                Console.WriteLine($" - {cell}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");

        }
    }
}
