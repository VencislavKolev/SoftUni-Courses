using System;
using System.Linq;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double totalSum = 0;
            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[i];
                double tempSum = 0;

                char firstChar = currWord[0];
                char lastChar = currWord[^1];
                int firstLetterPosition = -1;
                firstLetterPosition = AlphabeticalPosition(firstChar, firstLetterPosition);
                int secondLetterPosition = -1;
                secondLetterPosition = AlphabeticalPosition(lastChar, secondLetterPosition);

                double number = GetNumberFromChars(currWord);
                if (char.IsUpper(firstChar) && firstLetterPosition > 0)
                {
                    tempSum += number / firstLetterPosition;
                }
                else if (char.IsLower(firstChar) && firstLetterPosition > 0)
                {
                    tempSum = number * firstLetterPosition;
                }
                if (char.IsUpper(lastChar) && secondLetterPosition > 0)
                {
                    tempSum -= secondLetterPosition;
                }
                else if (char.IsLower(lastChar) && secondLetterPosition > 0)
                {
                    tempSum += secondLetterPosition;
                }
                totalSum += tempSum;
            }
            Console.WriteLine($"{totalSum:f2}");
        }

        private static int GetNumberFromChars(string currWord)
        {
            var numberAsChar = currWord.Skip(1).Take(currWord.Length - 2).ToArray();
            string numAsString = string.Join("", numberAsChar);
            return int.Parse(numAsString);
        }

        private static int AlphabeticalPosition(char currChar, int position)
        {
            if (char.IsLetter(currChar))
            {
                if (char.IsUpper(currChar))
                {
                    position = currChar - 64;
                }
                else if (char.IsLower(currChar))
                {
                    position = currChar - 96;
                }
            }

            return position;
        }
    }
}
