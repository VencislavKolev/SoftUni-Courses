using System;
using System.Diagnostics.SymbolStore;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];
            int eatenFood = 0;
            int snakeRow = -1;
            int snakeCol = -1;
            int firstBurrolRow = -1;
            int firstBurrolCol = -1;
            int secondBurrolRow = -1;
            int secondBurrolCol = -1;
            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < data.Length; col++)
                {
                    matrix[row, col] = data[col].ToString();
                    if (matrix[row, col] == "S")
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (matrix[row, col] == "B" && firstBurrolRow == -1)
                    {
                        firstBurrolRow = row;
                        firstBurrolCol = col;
                    }
                    else if (matrix[row, col] == "B" && secondBurrolRow == -1)
                    {
                        secondBurrolRow = row;
                        secondBurrolCol = col;
                    }
                }
            }

            bool isInside = CheckNewLocation(snakeRow, snakeCol, size);
            while (isInside && eatenFood < 10)
            {
                string command = Console.ReadLine();
                matrix[snakeRow, snakeCol] = ".";
                switch (command)
                {
                    case "left": snakeCol--; break;
                    case "right": snakeCol++; break;
                    case "up": snakeRow--; break;
                    case "down": snakeRow++; break;
                }

                isInside = CheckNewLocation(snakeRow, snakeCol, size);
                if (isInside)
                {
                    if (matrix[snakeRow, snakeCol] == "*")
                    {
                        eatenFood++;
                    }
                    else if (matrix[snakeRow, snakeCol] == "B")
                    {
                        matrix[snakeRow, snakeCol] = ".";
                        if (snakeRow == firstBurrolRow && snakeCol == firstBurrolCol)
                        {
                            snakeRow = secondBurrolRow;
                            snakeCol = secondBurrolCol;
                        }
                        else if (snakeRow == secondBurrolRow && snakeCol == secondBurrolRow)
                        {
                            snakeRow = firstBurrolRow;
                            snakeCol = firstBurrolCol;
                        }
                    }
                    matrix[snakeRow, snakeCol] = "S";
                }
            }
            if (!isInside)
            {
                Console.WriteLine("Game over!");
            }
            else if (eatenFood >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {eatenFood}");
            PrintMatrix(matrix);
        }
        private static bool CheckNewLocation(int snakeRow, int snakeCol, int size)
        {
            return snakeRow >= 0 && snakeRow < size && snakeCol >= 0 && snakeCol < size;
        }
        private static void PrintMatrix(string[,] matrix)
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

        private static void FillMatrix(int size, string[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < data.Length; col++)
                {
                    matrix[row, col] = data[col].ToString();
                }
            }
        }
    }
}
