using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int beeRow = -1;
            int beeCol = -1;
            for (int row = 0; row < n; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
            string command;
            int polinationedFlowers = 0;
            bool isInsideTerritory = true;
            while ((command = Console.ReadLine()) != "End")
            {
                matrix[beeRow, beeCol] = '.';
                switch (command)
                {
                    case "left": beeCol--; break;
                    case "right": beeCol++; break;
                    case "up": beeRow--; break;
                    case "down": beeRow++; break;
                }
                if (IsInside(matrix, beeRow, beeCol))
                {
                    if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        switch (command)
                        {
                            case "left": beeCol--; break;
                            case "right": beeCol++; break;
                            case "up": beeRow--; break;
                            case "down": beeRow++; break;
                        }
                    }
                    isInsideTerritory = IsInside(matrix, beeRow, beeCol);
                    if (isInsideTerritory == false)
                    {
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        polinationedFlowers++;
                    }
                    matrix[beeRow, beeCol] = 'B';
                }
                else
                {
                    isInsideTerritory = false;
                    break;
                }
                //   PrintMatrix(matrix);
            }
            if (isInsideTerritory == false)
            {
                Console.WriteLine("The bee got lost!");
            }
            if (polinationedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinationedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinationedFlowers} flowers more");
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
        private static bool IsInside(char[,] matrix, int beeRow, int beeCol)
        {
            return beeRow >= 0 && beeRow < matrix.GetLength(0) && beeCol >= 0 && beeCol < matrix.GetLength(1);
        }
    }
}
