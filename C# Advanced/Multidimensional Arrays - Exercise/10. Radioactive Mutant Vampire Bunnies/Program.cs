using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        //Полета
        static char[,] matrix;
        static int playerRow;
        static int playerCol;
        static bool isDead;
        static void Main(string[] args)
        {
            isDead = false;
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            matrix = new char[rows, columns];

            PopulateMatrix();

            char[] moves = Console.ReadLine().ToCharArray();
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'U':
                        MovePlayer(-1, 0);
                        break;
                    case 'D':
                        MovePlayer(1, 0);
                        break;
                    case 'L':
                        MovePlayer(0, -1);
                        break;
                    case 'R':
                        MovePlayer(0, 1);
                        break;
                    default:
                        break;
                }

                Spread();

                if (isDead)
                {
                    Print();
                    //last position of the player before a bunny hit him
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    Environment.Exit(0);
                }
            }
        }

        private static void Spread()
        {
            //Positions of all current bunnies before each spread
            List<int> bunnyIndexes = new List<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnyIndexes.Add(row);
                        bunnyIndexes.Add(col);
                    }
                }
            }
            for (int i = 0; i < bunnyIndexes.Count; i += 2)
            {
                int bunnyRow = bunnyIndexes[i];     //row
                int bunnyCol = bunnyIndexes[i + 1]; //col
                //up
                if (IsInside(bunnyRow - 1, bunnyCol))
                {
                    if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                    {
                        isDead = true;
                    }
                    matrix[bunnyRow - 1, bunnyCol] = 'B';
                }
                //down
                if (IsInside(bunnyRow + 1, bunnyCol))
                {
                    if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                    {
                        isDead = true;
                    }
                    matrix[bunnyRow + 1, bunnyCol] = 'B';
                }
                //left
                if (IsInside(bunnyRow, bunnyCol - 1))
                {
                    if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                    {
                        isDead = true;
                    }
                    matrix[bunnyRow, bunnyCol - 1] = 'B';
                }
                //right
                if (IsInside(bunnyRow, bunnyCol + 1))
                {
                    if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                    {
                        isDead = true;
                    }
                    matrix[bunnyRow, bunnyCol + 1] = 'B';
                }
            }
        }

        private static void MovePlayer(int row, int col)
        {
            if (!IsInside(playerRow + row, playerCol + col))
            {
                //after the player is out of the field
                //last position is replaced with free field '.'
                //to make sure after the spread a bunny doesnt hit 'P'
                matrix[playerRow, playerCol] = '.';
                Spread();
                Print();
                Console.WriteLine($"won: {playerRow} {playerCol}");
                Environment.Exit(0);
            }

            if (matrix[playerRow + row, playerCol + col] == 'B')
            {
                Spread();
                Print();
                Console.WriteLine($"dead: {playerRow + row} {playerCol + col}");
                Environment.Exit(0);
            }
            matrix[playerRow, playerCol] = '.';
            playerRow += row;
            playerCol += col;
            matrix[playerRow, playerCol] = 'P';
        }

        private static void Print()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void PopulateMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowElements = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
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
