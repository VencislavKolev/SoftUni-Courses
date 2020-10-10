using System;
using System.Linq;
using System.Security.Cryptography;

namespace _01._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            int[] allSums = new int[numberOfStrings];

            for (int i = 0; i < numberOfStrings; i++)
            {
                string name = Console.ReadLine();
                char[] nameArr = name.ToCharArray();

                int vowelSum = 0;
                int consonantSum = 0;
                for (int index = 0; index < nameArr.Length; index++)
                {
                    if (nameArr[index] == 'a' || nameArr[index] == 'e' || nameArr[index] == 'i'
                        || nameArr[index] == 'o' || nameArr[index] == 'u' ||
                        nameArr[index] == 'A' || nameArr[index] == 'E' || nameArr[index] == 'I'
                        || nameArr[index] == 'O' || nameArr[index] == 'U')
                    {
                        vowelSum += nameArr[index] * nameArr.Length;
                    }
                    else
                    {
                        consonantSum += nameArr[index] / nameArr.Length;
                    }
                }
                int currSum = vowelSum + consonantSum;
                allSums[i] = currSum;
            }
            Array.Sort(allSums);
            for (int i = 0; i < numberOfStrings; i++)
            {
                Console.WriteLine(allSums[i]);
            }
            //int[] desceningOrderedArray =
            //    (from i in allSums orderby i descending select i).ToArray();
            //Console.WriteLine(string.Join(" ", desceningOrderedArray));
        }
    }
}
