using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            int wordOneLength = words[0].Length;
            int wordTwoLength = words[1].Length;
            int maxLenght = Math.Max(wordOneLength, wordTwoLength);
            int minLenght = Math.Min(wordOneLength, wordTwoLength);
            int sum = 0;
            for (int i = 0; i < maxLenght; i++)
            {
                while (i < minLenght)
                {
                    sum += words[0][i] * words[1][i];
                    i++;
                }
                if (wordOneLength == wordTwoLength)
                {
                    break;
                }
                else if (i >= minLenght && minLenght == wordOneLength)
                {
                    sum += words[1][i];
                }
                else
                {
                    sum += words[0][i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
