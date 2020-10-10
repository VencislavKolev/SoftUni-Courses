using System;
using System.Linq;
using System.Security.Cryptography;

namespace train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = "";
            int bestCount = 0;
            int bestSum = 0;
            int bestBeginIndex = 0;
            string bestSequence = "";
            int bestSample = 0;
            int sample = 0;
            while ((input = Console.ReadLine()) != "Clone them!")
            {
                //1!0!1!1!0
                string sequence = input.Replace("!", "");
                //Замества ! с празен стринг
                //10110
                string[] dnaParts = sequence.Split("0", StringSplitOptions.RemoveEmptyEntries);
                //dnaParts [0] = "1"
                //dnaParts [1] = "11"
                sample++;
                int count = 0;
                int sum = 0;
                string bestSubSeq = "";
                foreach (string dnaPart in dnaParts)
                {
                    if (dnaPart.Length > count)
                    {
                        count = dnaPart.Length;
                        bestSubSeq = dnaPart;
                    }
                    sum += dnaPart.Length;
                }
                int beginIndex = sequence.IndexOf(bestSubSeq);
                //търси "11" на кой индекс започва "10110"  
                //започва на sequence[2]

                if (count > bestCount ||
                    (count == bestCount && beginIndex < bestBeginIndex) ||
                    (count == bestCount && beginIndex == bestBeginIndex && sum > bestSum) ||
                    sample == 1)
                {
                    bestCount = count;
                    bestSum = sum;
                    bestBeginIndex = beginIndex;
                    bestSequence = sequence;
                    bestSample = sample;
                }
            }
            char[] arrResult = bestSequence.ToCharArray();
            //10110 става масив от chars с всяка стойност
            //arrResult[0]=1 arrResult[1]=0 arrResult[2]=1 arrResult[3]=1 arrResult[4]=0
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", arrResult));
        }
    }
}