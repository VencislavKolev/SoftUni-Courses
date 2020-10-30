using System;
using System.Text;

namespace _2._Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder outputString = new StringBuilder(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            int playerRow = -1;
            int playerCol = -1;
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                matrix[playerRow, playerCol] = '-';
                switch (command)
                {
                    case "up": playerRow--; break;
                    case "down": playerRow++; break;
                    case "left": playerCol--; break;
                    case "right": playerCol++; break;
                }
                bool isInside = CheckNewPosition(matrix, playerRow, playerCol);
                if (isInside)
                {
                    if (char.IsLetter(matrix[playerRow, playerCol]))
                    {
                        char currChar = matrix[playerRow, playerCol];
                        outputString.Append(currChar);
                    }
                }
                else
                {
                    if (outputString.Length > 0)
                    {
                        outputString.Remove(outputString.Length - 1, 1);
                    }
                    switch (command)
                    {
                        case "up": playerRow++; break;
                        case "down": playerRow--; break;
                        case "left": playerCol++; break;
                        case "right": playerCol--; break;
                    }
                }
                matrix[playerRow, playerCol] = 'P';
            }
            Console.WriteLine(outputString);
            PrintMatrix(matrix);
        }
        private static bool CheckNewPosition(char[,] matrix, int playerRow, int playerCol)
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
