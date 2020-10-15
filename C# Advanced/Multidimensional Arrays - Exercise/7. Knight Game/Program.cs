using System;
using System.Collections.Generic;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] possibleMoves = new string[]
           {
                "(1, 2)", "(-1, 2)", "(2, -1)", "(-2, -1)",
                "(-1, -2)", "(1, -2)", "(-2, 1)", "(2, 1)"
           };
            int size = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[size, size];
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = rowValues[col];
                }
            }
            int knightsCount = 0;
            int killerRow = 0;
            int killerCol = 0;

            while (true)
            {
                int maxAttacks = 0;
                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        int currentKnightsAttacks = 0;
                        if (chessBoard[row, col] == 'K')
                        {
                            currentKnightsAttacks = 
                                AttackCheckForAllPossibleMoves
                                (possibleMoves, chessBoard, row, col, currentKnightsAttacks);
                        }
                        if (currentKnightsAttacks > maxAttacks)
                        {
                            maxAttacks = currentKnightsAttacks;
                            killerRow = row;
                            killerCol = col;
                        }
                    }
                }
                if (maxAttacks > 0)
                {
                    chessBoard[killerRow, killerCol] = '0';
                    knightsCount++;
                }
                else
                {
                    Console.WriteLine(knightsCount);
                    break;
                }
            }
        }

        private static int AttackCheckForAllPossibleMoves(string[] possibleMoves, char[,] chessBoard, int row, int col, int currentKnightsAttacks)
        {
            foreach (var move in possibleMoves)
            {
                string[] takePositions = move.Split(new string[] { ", ", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                int moveRow = int.Parse(takePositions[0]);
                int moveColumn = int.Parse(takePositions[1]);
                if (IsInside(chessBoard, row + moveRow, col + moveColumn) && chessBoard[row + moveRow, col + moveColumn] == 'K')
                {
                    currentKnightsAttacks++;
                }
            }

            return currentKnightsAttacks;
        }

        private static bool IsInside(char[,] chessBoard, int row, int col)
        {
            return row >= 0 && row < chessBoard.GetLength(0) &&
                col >= 0 && col < chessBoard.GetLength(1);
        }
    }
}
