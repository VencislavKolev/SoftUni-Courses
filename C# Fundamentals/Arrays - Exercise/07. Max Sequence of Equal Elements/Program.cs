using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().
                Select(int.Parse).ToArray();

            int maxCounter = 0;
            int bestIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currCounter = 1;

                int currElement = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currElement == arr[j])
                    {
                        currCounter++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currCounter > maxCounter)
                {
                    maxCounter = currCounter;
                    bestIndex = arr[i];
                }
            }
            string result = "";
            for (int i = 0; i < maxCounter; i++)
            {
                result += bestIndex + " ";
            }
            Console.WriteLine(result);
        }
    }
}
