using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = matrixSizes[0];
            int m = matrixSizes[1];
            int[,] matrix = new int[n, m];
            // PrintMatrix(matrix);

            List<int> coordiantes = new List<int>();
            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] data = command.Split()
                    .Select(int.Parse)
                    .ToArray();
                int row = data[0];
                int col = data[1];

                if (IsSafe(matrix, row, col))
                {
                    matrix[row, col] = 1;
                    coordiantes.Add(row);
                    coordiantes.Add(col);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            for (int i = 0; i < coordiantes.Count; i += 2)
            {
                int flowerRow = coordiantes[i];
                int flowerCol = coordiantes[i + 1];

                BloomUp(matrix, flowerRow - 1, flowerCol);
                BloomDown(matrix, flowerRow + 1, flowerCol);
                BloomLeft(matrix, flowerRow, flowerCol - 1);
                BloomRight(matrix, flowerRow, flowerCol + 1);

                //Bloom(matrix, flowerRow, flowerCol);
            }
            PrintMatrix(matrix);
        }

        //private static void Bloom(int[,] matrix, int flowerRow, int flowerCol)
        //{
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        if (i == flowerRow || i == flowerCol)
        //        {
        //            continue;
        //        }
        //        matrix[i, flowerCol]++;
        //        matrix[flowerRow, i]++;
        //    }
        //}

        private static void BloomRight(int[,] matrix, int flowerRow, int flowerCol)
        {
            while (flowerCol < matrix.GetLength(1))
            {
                matrix[flowerRow, flowerCol++]++;
            }
        }

        private static void BloomLeft(int[,] matrix, int flowerRow, int flowerCol)
        {
            while (flowerCol >= 0)
            {
                matrix[flowerRow, flowerCol--]++;
            }
        }

        private static void BloomDown(int[,] matrix, int flowerRow, int flowerCol)
        {
            while (flowerRow < matrix.GetLength(0))
            {
                matrix[flowerRow++, flowerCol]++;
            }
        }

        private static void BloomUp(int[,] matrix, int flowerRow, int flowerCol)
        {
            while (flowerRow >= 0)
            {
                matrix[flowerRow--, flowerCol]++;
            }
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
        private static bool IsSafe(int[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
