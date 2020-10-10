using System;

namespace _02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine(1);
            if (rows == 1)
            {
                return;
            }
            int[] initialArray = new int[] { 1, 1 };
            Console.WriteLine(string.Join(" ", initialArray));
            if (rows == 2)
            {
                return;
            }
            else
            {
                for (int i = 0; i < initialArray.Length + 1; i++)
                {
                    int[] newArr = new int[initialArray.Length + 1];
                    newArr[0] = 1;
                    newArr[newArr.Length - 1] = 1;
                    for (int j = 1; j < newArr.Length - 1; j++)
                    {
                        newArr[j] = initialArray[j - 1] + initialArray[j];
                    }
                    Console.WriteLine(string.Join(" ", newArr));
                    initialArray = newArr;
                    if (initialArray.Length == rows)
                    {
                        break;
                    }
                }
            }
        }
    }
}
