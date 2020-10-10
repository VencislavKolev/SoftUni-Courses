using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfNumbers = Console.ReadLine().Split()
                   .Select(int.Parse).ToList();
            string[] bombInfo = Console.ReadLine().Split();
            int specialBombNum = int.Parse(bombInfo[0]);
            int power = int.Parse(bombInfo[1]);
            int bombIndex = sequenceOfNumbers.IndexOf(specialBombNum);
            //ако няма вече индекс с исканото число връща -1
            while (bombIndex != -1)
            {

                int leftNumbers = bombIndex - power;
                int rightNumbers = bombIndex + power;
                if (leftNumbers < 0)
                {
                    leftNumbers = 0;
                }
                if (rightNumbers > sequenceOfNumbers.Count - 1)
                {
                    rightNumbers = sequenceOfNumbers.Count - 1;
                }
                //+1 защото да вземем и само бомб число
                int countNumbersToRemove = rightNumbers - leftNumbers + 1;
                sequenceOfNumbers.RemoveRange(leftNumbers, countNumbersToRemove);
                bombIndex = sequenceOfNumbers.IndexOf(specialBombNum);
            }
            Console.WriteLine(sequenceOfNumbers.Sum());
        }
    }
}
