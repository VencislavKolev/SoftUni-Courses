using System;
using System.Linq;
using System.Xml.Serialization;

namespace _4._Matrix_Shuffling
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
            string[,] matrix = ReadStringMatrix(rows, columns);
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                if (action == "swap" && cmdArgs.Length == 5)
                {
                    int row1 = int.Parse(cmdArgs[1]);
                    int col1 = int.Parse(cmdArgs[2]);
                    int row2 = int.Parse(cmdArgs[3]);
                    int col2 = int.Parse(cmdArgs[4]);

                    bool isValidFirstCell = IsValidCell(matrix, row1, col1);
                    bool isValidSecondCell = IsValidCell(matrix, row2, col2);

                    if (isValidFirstCell && isValidSecondCell)
                    {
                        string tempRow = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = tempRow;
                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
        private static bool IsValidCell(string[,] matrix, int row, int col)
        {
            bool isValid = false;
            if (row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1))
            {
                isValid = true;
            }
            return isValid;
        }
        private static void PrintMatrix(string[,] matrix)
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
        private static string[,] ReadStringMatrix(int rows, int columns)
        {
            string[,] matrix = new string[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                string[] matrixData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
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
