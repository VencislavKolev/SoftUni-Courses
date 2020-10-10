using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintNxNMatrix(num);
        }
        static void PrintNxNMatrix(int number)
        {
            for (int rows = 1; rows <= number; rows++)
            {
                for (int collumns = 1; collumns <= number; collumns++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
