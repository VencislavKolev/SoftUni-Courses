using System;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            int[,] matrix = ReadIntegerMatrix(rows, columns);

            int bestSum = int.MinValue;
            int bestRow = -1;
            int bestCol = -1;
            for (int row = 0; row <= rows - 3; row++)
            {
                for (int col = 0; col <= columns - 3; col++)
                {
                    int rowOneSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    int rowTwoSum = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    int rowThreeSum = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    int currSum = rowOneSum + rowTwoSum + rowThreeSum;

                    if (currSum > bestSum)
                    {
                        bestSum = currSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");
            for (int row = bestRow; row <= bestRow + 2; row++)
            {
                for (int col = bestCol; col <= bestCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        private static int[,] ReadIntegerMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                int[] matrixData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = matrixData[col];
                }
            }
            return matrix;
        }
    }
}
