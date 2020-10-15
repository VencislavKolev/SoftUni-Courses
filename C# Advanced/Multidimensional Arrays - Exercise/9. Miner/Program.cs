using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        //полета
        static char[,] matrix;
        static int minorRow;
        static int minorCol;
        static int coals;
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split();
            matrix = new char[fieldSize, fieldSize];
            PopulateMatrix();

            foreach (var currDirection in directions)
            {
                switch (currDirection)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"{coals} coals left. ({minorRow}, {minorCol})");
        }

        private static void Move(int row, int col)
        {
            if (IsInside(minorRow + row, minorCol + col))
            {
                minorRow += row;
                minorCol += col;
                if (matrix[minorRow, minorCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minorRow}, {minorCol})");
                    Environment.Exit(0);
                }
                else if (matrix[minorRow, minorCol] == 'c')
                {
                    coals--;
                    matrix[minorRow, minorCol] = '*';
                    if (coals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minorRow}, {minorCol})");
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void PopulateMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowSymbols = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowSymbols[col];
                    char currChar = matrix[row, col];
                    if (currChar == 's')
                    {
                        minorRow = row;
                        minorCol = col;
                    }
                    else if (currChar == 'c')
                    {
                        coals++;
                    }
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            bool isInside = false;
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                isInside = true;
            }
            return isInside;
        }
    }
}
