using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalCommands = int.Parse(Console.ReadLine());
            int playerRow = -1;
            int playerCol = -1;
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            bool isWinner = false;
            for (int i = 0; i < totalCommands; i++)
            {
                string command = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';
                switch (command)
                {
                    case "up": playerRow--; break;
                    case "down": playerRow++; break;
                    case "left": playerCol--; break;
                    case "right": playerCol++; break;
                }
                bool isInside = CheckIfInside(playerRow, playerCol, matrix);
                if (isInside)
                {
                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        switch (command)
                        {
                            case "up": playerRow--; break;
                            case "down": playerRow++; break;
                            case "left": playerCol--; break;
                            case "right": playerCol++; break;
                        }
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        switch (command)
                        {
                            case "up": playerRow++; break;
                            case "down": playerRow--; break;
                            case "left": playerCol++; break;
                            case "right": playerCol--; break;
                        }
                    }
                    isInside = CheckIfInside(playerRow, playerCol, matrix);
                    if (!isInside)
                    {
                        if (playerRow == -1)
                        {
                            playerRow = matrix.GetLength(0) - 1;

                        }
                        else if (playerRow == matrix.GetLength(0))
                        {
                            playerRow = 0;
                        }
                        else if (playerCol == -1)
                        {
                            playerCol = matrix.GetLength(1) - 1;
                        }
                        else if (playerCol == matrix.GetLength(1))
                        {
                            playerCol = 0;
                        }
                    }
                }
                else
                {
                    if (playerRow == -1)
                    {
                        playerRow = matrix.GetLength(0) - 1;

                    }
                    else if (playerRow == matrix.GetLength(0))
                    {
                        playerRow = 0;
                    }
                    else if (playerCol == -1)
                    {
                        playerCol = matrix.GetLength(1) - 1;
                    }
                    else if (playerCol == matrix.GetLength(1))
                    {
                        playerCol = 0;
                    }
                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    isWinner = true;
                    matrix[playerRow, playerCol] = 'f';
                    break;
                }
                matrix[playerRow, playerCol] = 'f';
                // PrintMatrix(matrix);
            }
            if (isWinner)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);
        }

        private static bool CheckIfInside(int playerRow, int playerCol, char[,] matrix)
        {
            return playerRow >= 0 && playerRow < matrix.GetLength(0) && playerCol >= 0 && playerCol < matrix.GetLength(1);
        }

        private static void PrintMatrix(char[,] matrix)
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
    }
}
