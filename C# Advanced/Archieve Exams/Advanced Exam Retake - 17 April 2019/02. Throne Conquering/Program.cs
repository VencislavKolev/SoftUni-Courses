using System;
using System.Threading;

namespace _02._Throne_Conquering
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int parisRow = -1;
            int parisCol = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }
            bool isDead = false;
            bool isWinner = false;
            while (!isDead && !isWinner)
            {
                string[] inputData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.None);
                string command = inputData[0];
                int spartanRow = int.Parse(inputData[1]);
                int spartanCol = int.Parse(inputData[2]);
                matrix[spartanRow, spartanCol] = 'S';

                energy--;
                matrix[parisRow, parisCol] = '-';

                switch (command)
                {
                    case "left": parisCol--; break;
                    case "right": parisCol++; break;
                    case "up": parisRow--; break;
                    case "down": parisRow++; break;
                    default: break;
                }
                bool isInside = CheckNewPosition(matrix, parisRow, parisCol);
                if (isInside == false)
                {
                    switch (command)
                    {
                        case "left": parisCol++; break;
                        case "right": parisCol--; break;
                        case "up": parisRow++; break;
                        case "down": parisRow--; break;
                    }
                    matrix[parisRow, parisCol] = 'P';
                    if (energy <= 0)
                    {
                        isDead = true;
                    }
                }
                else if (isInside)
                {

                    if (matrix[parisRow, parisCol] == 'S')
                    {
                        energy -= 2;
                        if (energy <= 0)
                        {
                            isDead = true;
                        }
                        else
                        {
                            matrix[parisRow, parisCol] = 'P';
                        }
                    }
                    else if (matrix[parisRow, parisCol] == 'H')
                    {
                        isWinner = true;
                    }
                    else
                    {
                        if (energy > 0)
                        {
                            matrix[parisRow, parisCol] = 'P';
                        }
                        else
                        {
                            isDead = true;
                        }
                    }
                }
                //PrintMatrix(matrix);
            }
            if (isDead)
            {
                matrix[parisRow, parisCol] = 'X';
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }
            else if (isWinner)
            {
                matrix[parisRow, parisCol] = '-';
                Console.WriteLine($"Paris has successfully sat on the throne! Energy left: {energy}");
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
        private static bool CheckNewPosition(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
