using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = inputData[0];
            int cols = inputData[1];
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
            int sum = 0;
            foreach (var element in matrix)
            {
                sum += element;
            }
            Console.WriteLine(sum);
        }
    }
}
