using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
            int receivedIndex = int.Parse(Console.ReadLine());
            List<int> removedIntegers = new List<int>();
            int currNum = 0;
            while (sequence.Count != 0)
            {
                if (receivedIndex < 0)
                {
                    currNum = sequence[0];
                    removedIntegers.Add(currNum);
                    sequence.RemoveAt(0);
                    sequence.Insert(0, sequence[sequence.Count - 1]);
                    UpdatedSequence(sequence, currNum);

                }
                else if (receivedIndex > sequence.Count - 1)
                {
                    currNum = sequence[sequence.Count - 1];
                    removedIntegers.Add(currNum);
                    sequence.RemoveAt(sequence.Count - 1);
                    sequence.Add(sequence[0]);
                    UpdatedSequence(sequence, currNum);
                }
                else
                {
                    currNum = sequence[receivedIndex];
                    removedIntegers.Add(currNum);
                    sequence.RemoveAt(receivedIndex);
                    UpdatedSequence(sequence, currNum);
                }
                if (sequence.Count == 0)
                {
                    break;
                }
                receivedIndex = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(removedIntegers.Sum());
        }
        static List<int> UpdatedSequence(List<int> sequence, int num)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] <= num)
                {
                    sequence[i] += num;
                }
                else
                {
                    sequence[i] -= num;
                }
            }
            return sequence;
        }

    }
}
