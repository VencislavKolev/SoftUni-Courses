using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1._Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materialInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] magicInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> magic = new Queue<int>(magicInput);
            Stack<int> materials = new Stack<int>(materialInput);
            Dictionary<string, int> toysDict = new Dictionary<string, int>();
            string doll = "Doll";
            string woodenTrain = "Wooden train";
            string teddyBear = "Teddy bear";
            string bicycle = "Bicycle";
            toysDict.Add(doll, 0);
            toysDict.Add(woodenTrain, 0);
            toysDict.Add(teddyBear, 0);
            toysDict.Add(bicycle, 0);

            while (magic.Count > 0 && materials.Count > 0)
            {
                int currMagicValue = magic.Peek();
                int currMaterialValue = materials.Peek();
                int result = currMagicValue * currMaterialValue;
                bool isPresent = result == 150 || result == 250 || result == 300 || result == 400;
                if (isPresent)
                {
                    switch (result)
                    {
                        case 150: toysDict[doll]++; break;
                        case 250: toysDict[woodenTrain]++; break;
                        case 300: toysDict[teddyBear]++; break;
                        case 400: toysDict[bicycle]++; break;
                    }
                    materials.Pop();
                    magic.Dequeue();
                }
                else
                {
                    if (result < 0)
                    {
                        result = currMagicValue + currMaterialValue;
                        magic.Dequeue();
                        materials.Pop();
                        materials.Push(result);
                    }
                    else if (result > 0)
                    {
                        magic.Dequeue();
                        materials.Pop();
                        materials.Push(currMaterialValue + 15);
                    }
                    else
                    {
                        if (currMaterialValue == 0)
                        {
                            materials.Pop();
                        }
                        if (currMagicValue == 0)
                        {
                            magic.Dequeue();
                        }
                    }
                }
            }
            bool firstValidPair = toysDict[doll] > 0 && toysDict[woodenTrain] > 0;
            bool secondValidPair = toysDict[teddyBear] > 0 && toysDict[bicycle] > 0;
            if (firstValidPair || secondValidPair)
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
            if (magic.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magic)}");
            }
            foreach (var (toyName, amount) in toysDict
                .Where(x => x.Value > 0)
                .OrderBy(x => x.Key))
            {
                Console.WriteLine($"{toyName}: {amount}");
            }
        }
    }
}
