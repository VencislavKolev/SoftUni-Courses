using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int rows = inputData[0];
            int columns = inputData[1];
            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
            for (int col = 0; col < columns; col++)
            {
                int columnSum = 0;
                for (int row = 0; row < rows; row++)
                {
                    columnSum += matrix[row, col];
                }
                Console.WriteLine(columnSum);
            }
        }
    }
}
