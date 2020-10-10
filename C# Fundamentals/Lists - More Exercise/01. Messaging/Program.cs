using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string message = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numbers.Count; i++)
            {
                int digitSum = 0;
                while (numbers[i] != 0)
                {
                    digitSum += numbers[i] % 10;
                    numbers[i] = numbers[i] / 10;
                }
                if (digitSum >= message.Length)
                {
                    digitSum -= message.Length;
                }
                sb.Append(message[digitSum]);
                message = message.Remove(digitSum, 1);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
