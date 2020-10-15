using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = data[0];
            int columns = data[1];
            char[,] matrix = new char[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                char[] rowValues = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
            int twoByTwoPairsCount = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        twoByTwoPairsCount++;
                    }
                }
            }
            Console.WriteLine(twoByTwoPairsCount);
        }
    }
}
