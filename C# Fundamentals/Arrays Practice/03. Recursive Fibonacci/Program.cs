using System;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] arr = new int[] { 1, 1 };
            if (number == 1)
            {
                Console.WriteLine(1);
            }
            else if (number == 2)
            {
                Console.WriteLine(1);
            }
            else
            {
                for (int i = 1; i < number - 1; i++)
                {
                    int[] newArr = new int[arr.Length];
                    newArr[0] = arr[1];
                    newArr[1] = arr[0] + arr[1];
                    arr = newArr;
                }
                Console.WriteLine(arr[arr.Length - 1]);
            }
        }
    }
}
