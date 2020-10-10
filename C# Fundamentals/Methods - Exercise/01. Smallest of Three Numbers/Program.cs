using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstN = int.Parse(Console.ReadLine());
            int secondN = int.Parse(Console.ReadLine());
            int thirdN = int.Parse(Console.ReadLine());
            int result = PrintSmallestOfThreeNumbers(firstN, secondN, thirdN);
            Console.WriteLine(result);
        }
        static int PrintSmallestOfThreeNumbers(int a, int b, int c)
        {
            int result = Math.Min(a, Math.Min(b, c));
            return result;
        }
    }
}
