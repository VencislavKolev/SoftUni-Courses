using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersDict = new Dictionary<int, int>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbersDict.ContainsKey(number))
                {
                    numbersDict.Add(number, 0);
                }
                numbersDict[number]++;
            }
            //foreach (var number in numbersDict)
            //{
            //    if (number.Value % 2 == 0)
            //    {
            //        Console.WriteLine(number.Key);
            //        break;
            //    }
            //}
            KeyValuePair<int, int> result = numbersDict
                .First(x => x.Value % 2 == 0);
            Console.WriteLine(result.Key);
        }
    }
}
