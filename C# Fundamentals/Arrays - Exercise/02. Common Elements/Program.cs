using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();
            string commonElements = null;

            foreach (string word1 in arr2)
            {
                foreach (string word2 in arr1)
                {
                    if (word1 == word2)
                    {
                        commonElements += word1 + " ";
                    }
                }
            }
            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    for (int j = 0; j < arr1.Length; j++)
            //    {
            //        if (arr2[i] == arr1[j])
            //        {
            //            commonElements += arr2[i] + " ";
            //        }
            //    }
            //}

            Console.WriteLine(commonElements);
        }
    }
}
