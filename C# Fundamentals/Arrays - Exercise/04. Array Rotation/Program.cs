using System;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            int rotations = int.Parse(Console.ReadLine());
            rotations = rotations % arr1.Length;
            for (int index = 0; index < rotations; index++)
            {
                string temp = temp = arr1[0];
                for (int i = 0; i < arr1.Length - 1; i++)
                {
                    arr1[i] = arr1[i + 1];
                }
                arr1[arr1.Length - 1] = temp;
            }
            Console.WriteLine(string.Join(" ", arr1));
        }
    }
}
