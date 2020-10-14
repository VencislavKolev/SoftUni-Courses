using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[rows][];
            if (rows >= 1)
            {
                pascalTriangle[0] = new long[] { 1 };
            }
            if (rows >= 2)
            {
                pascalTriangle[1] = new long[] { 1, 1 };
            }

            for (int row = 2; row < rows; row++)
            {
                //initialize new row with row+1 columns
                pascalTriangle[row] = new long[row + 1];
                //first column of each row = 1
                pascalTriangle[row][0] = 1;
                for (int col = 1; col < row; col++)
                {
                    pascalTriangle[row][col] =
                        pascalTriangle[row - 1][col - 1] +
                        pascalTriangle[row - 1][col];
                }
                //last column of each row = 1
                pascalTriangle[row][row] = 1;
            }

            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
