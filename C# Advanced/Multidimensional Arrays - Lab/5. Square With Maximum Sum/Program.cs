using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int columns = matrixSize[1];
            int[,] matrix = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
            int biggestSum = int.MinValue;
            int bestRow = 0;
            int bestColumn = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                int currSquareSum = 0;
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    currSquareSum = matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1];
                    if (currSquareSum > biggestSum)
                    {
                        biggestSum = currSquareSum;
                        bestRow = row;
                        bestColumn = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[bestRow, bestColumn]} {matrix[bestRow, bestColumn + 1]} " +
                $"{Environment.NewLine}{matrix[bestRow + 1, bestColumn]} {matrix[bestRow + 1, bestColumn + 1]}");
            Console.WriteLine(biggestSum);
        }
    }
}
