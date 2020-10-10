using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            //int totalPeople = 0;
            int[] train = new int[wagons];
            for (int i = 0; i < train.Length; i++)
            {
                train[i] = int.Parse(Console.ReadLine());
            }
            //for (int i = 0; i < train.Length; i++)
            //{
            //    totalPeople += train[i];
            //}
            Console.WriteLine(string.Join(" ", train));
            Console.WriteLine(train.Sum());
            //Console.WriteLine(totalPeople);
        }
    }
}
