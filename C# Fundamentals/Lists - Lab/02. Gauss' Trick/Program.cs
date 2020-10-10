using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            for (int i = 0; i < numbers.Count / 2; i++)
            {
                Console.Write(numbers[i] + numbers[numbers.Count - 1 - i] + " ");
            }
            if (numbers.Count % 2 == 1)
            {
                //ако има НЕЧЕТЕН брой елементи отпечатай средния елемент
                // 1 2 3 4 5 
                //5/2=2 индекс(СРЕДНИЯ индекс)
                Console.Write(numbers[numbers.Count / 2]);
            }
        }
    }
}
