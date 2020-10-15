using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //DOUBLE!!!
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArr = new double[rows][];
            for (int row = 0; row < rows; row++)
            {
                jaggedArr[row] = Console.ReadLine()
                     .Split()
                     .Select(double.Parse)
                     .ToArray();

                //int[] rowValues = Console.ReadLine()
                //    .Split()
                //    .Select(int.Parse)
                //    .ToArray();
                //jaggedArr[row] = rowValues;

                //int[] numbers = Console.ReadLine()
                //    .Split()
                //    .Select(int.Parse)
                //    .ToArray();
                //jaggedArr[row] = new int[numbers.Length];
                //for (int col = 0; col < jaggedArr[row].Length; col++)
                //{
                //    jaggedArr[row][col] = numbers[col];
                //}
            }
            Analyze(jaggedArr);
            string inputCommand;
            while ((inputCommand = Console.ReadLine()) != "End")
            {
                string[] inputArgs = inputCommand.Split();
                string action = inputArgs[0];
                int givenRow = int.Parse(inputArgs[1]);
                int givenCol = int.Parse(inputArgs[2]);
                int value = int.Parse(inputArgs[3]);
                if (action == "Add")
                {
                    if (IsValidCell(jaggedArr, givenRow, givenCol))
                    {
                        jaggedArr[givenRow][givenCol] += value;
                    }
                }
                else if (action == "Subtract")
                {
                    if (IsValidCell(jaggedArr, givenRow, givenCol))
                    {
                        jaggedArr[givenRow][givenCol] -= value;
                    }
                }
            }
            foreach (var row in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }

        private static void Analyze(double[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.Length - 1; row++)
            {
                int currRowLen = jaggedArr[row].Length;
                int nextRowLen = jaggedArr[row + 1].Length;
                if (currRowLen == nextRowLen)
                {
                    MultiplyRowElements(jaggedArr, row);
                }
                else
                {
                    DivideRowElements(jaggedArr, row);
                }
            }
        }

        private static bool IsValidCell(double[][] jaggedArr, int row, int column)
        {
            bool isValid = false;
            if (row >= 0 && row < jaggedArr.Length &&
                column >= 0 && column < jaggedArr[row].Length)
            {
                isValid = true;
            }
            return isValid;
        }
        private static void DivideRowElements(double[][] jaggedArr, int currRow)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int col = 0; col < jaggedArr[currRow + i].Length; col++)
                {
                    jaggedArr[currRow + i][col] /= 2;
                }
            }
        }
        private static void MultiplyRowElements(double[][] jaggedArr, int currRow)
        {
            for (int col = 0; col < jaggedArr[currRow].Length; col++)
            {
                jaggedArr[currRow][col] *= 2;
                jaggedArr[currRow + 1][col] *= 2;
            }
        }
    }
}
