using System;

namespace _02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstPlayerRow = -1;
            int firstPlayerCol = -1;
            int secondPlayerRow = -1;
            int secondPlayerCol = -1;
            char[,] matrix = new char[n, n];
            FillMatrix(n, ref firstPlayerRow, ref firstPlayerCol, ref secondPlayerRow, ref secondPlayerCol, matrix);
            //    bool isDead = false;
            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string cmdOne = cmdArgs[0];
                string cmdTwo = cmdArgs[1];
                switch (cmdOne)
                {
                    case "up": firstPlayerRow--; break;
                    case "down": firstPlayerRow++; break;
                    case "left": firstPlayerCol--; break;
                    case "right": firstPlayerCol++; break;
                }
                bool isInside = CheckNewPosition(matrix, firstPlayerRow, firstPlayerCol);
                if (isInside)
                {
                    if (matrix[firstPlayerRow, firstPlayerCol] != 's')
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'f';
                    }
                    else
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'x';
                        break;
                    }
                }
                else
                {
                    if (firstPlayerRow == -1)
                    {
                        firstPlayerRow = matrix.GetLength(0) - 1;
                    }
                    else if (firstPlayerRow == matrix.GetLength(0))
                    {
                        firstPlayerRow = 0;
                    }
                    else if (firstPlayerCol == -1)
                    {
                        firstPlayerCol = matrix.GetLength(1) - 1;
                    }
                    else if (firstPlayerCol == matrix.GetLength(0))
                    {
                        firstPlayerCol = 0;
                    }
                    if (matrix[firstPlayerRow, firstPlayerCol] != 's')
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'f';
                    }
                    else
                    {
                        matrix[firstPlayerRow, firstPlayerCol] = 'x';
                        break;
                    }
                }
                switch (cmdTwo)
                {
                    case "up": secondPlayerRow--; break;
                    case "down": secondPlayerRow++; break;
                    case "left": secondPlayerCol--; break;
                    case "right": secondPlayerCol++; break;
                }
                isInside = CheckNewPosition(matrix, secondPlayerRow, secondPlayerCol);
                if (isInside)
                {
                    if (matrix[secondPlayerRow, secondPlayerCol] != 'f')
                    {
                        matrix[secondPlayerRow, secondPlayerCol] = 's';
                    }
                    else
                    {
                        matrix[secondPlayerRow, secondPlayerCol] = 'x';
                        break;
                    }
                }
                else
                {
                    if (secondPlayerRow == -1)
                    {
                        secondPlayerRow = matrix.GetLength(0) - 1;
                    }
                    else if (secondPlayerRow == matrix.GetLength(0))
                    {
                        secondPlayerRow = 0;
                    }
                    else if (secondPlayerCol == -1)
                    {
                        secondPlayerCol = matrix.GetLength(1) - 1;
                    }
                    else if (secondPlayerCol == matrix.GetLength(0))
                    {
                        secondPlayerCol = 0;
                    }
                    if (matrix[secondPlayerRow, secondPlayerCol] != 'f')
                    {
                        matrix[secondPlayerRow, secondPlayerCol] = 's';
                    }
                    else
                    {
                        matrix[secondPlayerRow, secondPlayerCol] = 'x';
                        break;
                    }
                }
                //  PrintMatrix(matrix);
            }
            PrintMatrix(matrix);

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
        private static bool CheckNewPosition(char[,] matrix, int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < matrix.GetLength(0) && playerCol >= 0 && playerCol < matrix.GetLength(1);
        }

        private static void FillMatrix(int n, ref int firstPlayerRow, ref int firstPlayerCol, ref int secondPlayerRow, ref int secondPlayerCol, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col];
                    char currChar = matrix[row, col];
                    if (currChar == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (currChar == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }
        }
    }
}
