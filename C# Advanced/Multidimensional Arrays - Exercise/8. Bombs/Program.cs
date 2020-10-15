using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(size);

            string[] bombCoordinates = Console.ReadLine()
                .Split();
            List<int[]> data = new List<int[]>();

            AddBombCoordinates(bombCoordinates, data);
            Explosion(data, matrix);

            int aliveCells = 0;
            long sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] >= 1)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrix(matrix);
        }

        private static int[,] ReadMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowValues = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            return matrix;
        }

        private static void Explosion(List<int[]> data, int[,] matrix)
        {
            foreach (var bomb in data)
            {
                int bombRow = bomb[0];
                int bombCol = bomb[1];
                int bombValue = matrix[bombRow, bombCol];
                if (bombValue > 0)
                {
                    if (IsEligableToExplode(bombRow - 1, bombCol - 1, matrix))
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bombValue;
                    }
                    if (IsEligableToExplode(bombRow - 1, bombCol, matrix))
                    {
                        matrix[bombRow - 1, bombCol] -= bombValue;
                    }
                    if (IsEligableToExplode(bombRow - 1, bombCol + 1, matrix))
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bombValue;
                    }
                    if (IsEligableToExplode(bombRow + 1, bombCol - 1, matrix))
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bombValue;
                    }
                    if (IsEligableToExplode(bombRow + 1, bombCol, matrix))
                    {
                        matrix[bombRow + 1, bombCol] -= bombValue;
                    }
                    if (IsEligableToExplode(bombRow + 1, bombCol + 1, matrix))
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bombValue;
                    }
                    if (IsEligableToExplode(bombRow, bombCol - 1, matrix))
                    {
                        matrix[bombRow, bombCol - 1] -= bombValue;
                    }
                    if (IsEligableToExplode(bombRow, bombCol + 1, matrix))
                    {
                        matrix[bombRow, bombCol + 1] -= bombValue;
                    }
                    matrix[bombRow, bombCol] = 0;
                }
            }
        }
        private static bool IsEligableToExplode(int row, int col, int[,] matrix)
        {
            bool isEligable = false;
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1) &&
                matrix[row, col] > 0)
            {
                isEligable = true;
            }
            return isEligable;
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void AddBombCoordinates(string[] bombCoordinates, List<int[]> data)
        {
            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                int[] bomb = bombCoordinates[i]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
                data.Add(bomb);
            }
        }
    }
}
