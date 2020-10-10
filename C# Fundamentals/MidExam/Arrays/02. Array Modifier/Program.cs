using System;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();
                string action = tokens[0];
                int firstIndex, secondIndex;
                if (action == "swap")
                {
                    firstIndex = int.Parse(tokens[1]);
                    secondIndex = int.Parse(tokens[2]);
                    int temp = numbers[firstIndex];
                    numbers[firstIndex] = numbers[secondIndex];
                    numbers[secondIndex] = temp;
                }
                else if (action == "multiply")
                {
                    firstIndex = int.Parse(tokens[1]);
                    secondIndex = int.Parse(tokens[2]);
                    numbers[firstIndex] *= numbers[secondIndex];
                }
                else if (action == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] -= 1;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
