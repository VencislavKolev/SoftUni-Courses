﻿using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split().
                Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split().
                Select(int.Parse).ToArray();

            int sumArr1 = 0;
            bool areIdentical = false;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    areIdentical = false;
                    break;
                }
                else
                {
                    areIdentical = true;
                    sumArr1 += arr1[i];
                }
            }
            if (areIdentical == true)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumArr1}");
            }
        }
    }
}