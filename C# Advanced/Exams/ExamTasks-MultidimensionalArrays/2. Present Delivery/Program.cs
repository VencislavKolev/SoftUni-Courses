using System;

namespace _2._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int santaRow = -1;
            int santaCol = -1;
            int niceKids = 0;
            int niceKidsWithPresent = 0;
            int presentCount = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string[] data = Console.ReadLine().Split();
                string rowData = string.Join("", data);
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                    }
                    else if (matrix[row, col] == 'V')
                    {
                        niceKids++;
                    }
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "Christmas morning")
            {
                matrix[santaRow, santaCol] = '-';
                switch (command)
                {
                    case "left": santaCol--; break;
                    case "right": santaCol++; break;
                    case "up": santaRow--; break;
                    case "down": santaRow++; break;
                }
                if (matrix[santaRow, santaCol] == 'X')
                {
                    matrix[santaRow, santaCol] = '-';
                }
                else if (matrix[santaRow, santaCol] == 'V')
                {
                    presentCount--;
                    niceKidsWithPresent++;
                    matrix[santaRow, santaCol] = '-';
                }
                else if (matrix[santaRow, santaCol] == 'C')
                {
                    bool isKidLeft = matrix[santaRow, santaCol - 1] == 'V' || matrix[santaRow, santaCol - 1] == 'X'; 
                    if (isKidLeft)
                    {
                        if (matrix[santaRow, santaCol - 1] == 'V')
                        {
                            niceKidsWithPresent++;
                            presentCount--;
                        }
                        else if (matrix[santaRow, santaCol - 1] == 'X')
                        {
                            presentCount--;
                        }
                        matrix[santaRow, santaCol - 1] = '-';
                    }
                    bool isKidRight = matrix[santaRow, santaCol + 1] == 'V' || matrix[santaRow, santaCol + 1] == 'X';
                    if (isKidRight)
                    {
                        if (matrix[santaRow, santaCol + 1] == 'V')
                        {
                            niceKidsWithPresent++;
                            presentCount--;
                        }
                        else if (matrix[santaRow, santaCol + 1] == 'X')
                        {
                            presentCount--;
                        }
                        matrix[santaRow, santaCol + 1] = '-';
                    }
                    bool isKidUp = matrix[santaRow - 1, santaCol] == 'V' || matrix[santaRow - 1, santaCol] == 'X';
                    if (isKidUp)
                    {
                        if (matrix[santaRow - 1, santaCol] == 'V')
                        {
                            niceKidsWithPresent++;
                            presentCount--;
                        }
                        else if (matrix[santaRow - 1, santaCol] == 'X')
                        {
                            presentCount--;
                        }
                        matrix[santaRow - 1, santaCol] = '-';
                    }
                    bool isKidDown = matrix[santaRow - 1, santaCol] == 'V' || matrix[santaRow - 1, santaCol] == 'X';
                    if (isKidDown)
                    {
                        if (matrix[santaRow + 1, santaCol] == 'V')
                        {
                            niceKidsWithPresent++;
                            presentCount--;
                        }
                        else if (matrix[santaRow + 1, santaCol] == 'X')
                        {
                            presentCount--;
                        }
                        matrix[santaRow + 1, santaCol] = '-';
                    }
                }
                matrix[santaRow, santaCol] = 'S';
                //   PrintMatrix(matrix);
                if (presentCount == 0)
                {
                    break;
                }
            }
            if (presentCount == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            PrintMatrix(matrix);
            if (niceKidsWithPresent == niceKids)
            {
                Console.WriteLine($"Good job, Santa! {niceKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKids - niceKidsWithPresent} nice kid/s.");
            }
        }
        private static void PrintMatrix(char[,] matrix)
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
    }
}
