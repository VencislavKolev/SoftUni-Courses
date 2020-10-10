using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputToArr = input.Split();

                if (inputToArr[0] == "exchange")
                {
                    string command = inputToArr[0];
                    int index = int.Parse(inputToArr[1]);
                    if (index < 0 || index > arr.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    Exchange(arr, index);
                }
                else if (inputToArr[0] == "max")
                {
                    if (inputToArr[1] == "even")
                    {
                        if (MaxEven(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MaxEven(arr));
                    }
                    else if (inputToArr[1] == "odd")
                    {
                        if (MaxOdd(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MaxOdd(arr));
                    }
                }
                else if (inputToArr[0] == "min")
                {
                    if (inputToArr[1] == "even")
                    {
                        if (MinEven(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MinEven(arr));
                    }
                    else if (inputToArr[1] == "odd")
                    {
                        if (MinOdd(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MinOdd(arr));
                    }
                }
                else if (inputToArr[0] == "first")
                {
                    int count = int.Parse(inputToArr[1]);
                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    if (inputToArr[2] == "even")
                    {
                        ReturnFirstEven(count, arr);
                    }
                    else if (inputToArr[2] == "odd")
                    {
                        ReturnFirstOdd(count, arr);
                    }
                }
                else if (inputToArr[0] == "last")
                {
                    int count = int.Parse(inputToArr[1]);
                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    if (inputToArr[2] == "even")
                    {
                        ReturnLastEven(count, arr);
                    }
                    else if (inputToArr[2] == "odd")
                    {
                        ReturnLastOdd(count, arr);
                    }
                }
            }
            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }
        static void Exchange(int[] array, int index)
        {
            //[1, 2, 3, 4, 5]
            //exchange 2 (след 2ри ИНДЕКС --> след 3ката)
            //firstArr 4,5 
            //secondArr 1,2,3
            //array=[4, 5, 1, 2, 3]
            int[] firstArr = new int[array.Length - index - 1];
            int[] secondArr = new int[index + 1];
            for (int i = 0; i < firstArr.Length; i++)
            {
                firstArr[i] = array[index + 1 + i];
            }
            for (int i = 0; i < secondArr.Length; i++)
            {
                secondArr[i] = array[i];
            }
            for (int i = 0; i < firstArr.Length; i++)
            {
                array[i] = firstArr[i];
            }
            for (int i = 0; i < secondArr.Length; i++)
            {
                array[firstArr.Length + i] = secondArr[i];
            }

        }
        static int MaxEven(int[] array)
        {
            //[1, 4, 8, 2, 3] -> max odd -> print 4 index (3-ката)
            int maxEven = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] >= maxEven)
                    {
                        maxEven = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }
        static int MinEven(int[] array)
        {
            //[1, 4, 8, 2, 3] -> min odd -> print 3 index (2-ката)
            int MinEven = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] <= MinEven)
                    {
                        MinEven = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }
        static int MaxOdd(int[] array)
        {
            int MaxOdd = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] >= MaxOdd)
                    {
                        MaxOdd = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }
        static int MinOdd(int[] array)
        {
            int MinOdd = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] <= MinOdd)
                    {
                        MinOdd = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }
        static void ReturnFirstEven(int count, int[] array)
        {
            int currCount = 0;
            string numbers = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    currCount++;
                    numbers += array[i] + " ";
                }
                if (currCount == count)
                {
                    break;
                }
            }
            if (currCount == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                string[] result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }
        static void ReturnFirstOdd(int count, int[] array)
        {
            int currCount = 0;
            string numbers = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    currCount++;
                    numbers += array[i] + " ";
                }
                if (currCount == count)
                {
                    break;
                }
            }
            if (currCount == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                string[] result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }
        static void ReturnLastEven(int count, int[] array)
        {
            int currCount = 0;
            string numbers = "";
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    currCount++;
                    numbers += array[i] + " ";
                }
                if (currCount == count)
                {
                    break;
                }
            }
            if (currCount == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Reverse();
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }
        static void ReturnLastOdd(int count, int[] array)
        {
            int currCount = 0;
            string numbers = "";
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    currCount++;
                    numbers += array[i] + " ";
                }
                if (currCount == count)
                {
                    break;
                }
            }
            if (currCount == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Reverse();
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }
    }
}
