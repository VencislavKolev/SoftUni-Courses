using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                int[] matrixData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                jaggedArr[row] = matrixData;
                //  matrix[row] = new int[matrixData.Length];
                //for (int col = 0; col < n; col++)
                //{
                //    matrix[row][col] = matrixData[col];
                //}
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int columns = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);
                if (row < 0
                    || row >= rows
                    || columns < 0
                    || columns >= jaggedArr[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (action == "Add")
                {
                    jaggedArr[row][columns] += value;
                }
                else if (action == "Subtract")
                {
                    jaggedArr[row][columns] -= value;
                }
            }
            //for (int row = 0; row < matrix.Length; row++)
            //{
            //    for (int col = 0; col < matrix[row].Length; col++)
            //    {
            //        Console.Write(matrix[row][col] + " ");
            //    }
            //    Console.WriteLine();
            //}
            foreach (int[] currentRow in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", currentRow));
            }
        }
    }
}
