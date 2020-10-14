using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            bool isFound = false;
            for (int row = 0; row < n; row++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }
            char symbolToFind = char.Parse(Console.ReadLine());
            int[] foundSymbCoordinates = new int[2];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    char currSymb = matrix[row, col];
                    if (currSymb == symbolToFind)
                    {
                        foundSymbCoordinates[0] = row;
                        foundSymbCoordinates[1] = col;
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            if (isFound == false)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
            else
            {
                Console.WriteLine($"({string.Join(", ", foundSymbCoordinates)})");
            }
        }
    }
}
