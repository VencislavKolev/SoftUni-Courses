using System;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());
            MultiplicationSign(numOne, numTwo, numThree);

        }
        static void MultiplicationSign(int one, int two, int three)
        {
            if (one == 0 || two == 0 || three == 0)
            {
                Console.WriteLine("zero");
            }
            //ако има ЧЕТЕН БРОЙ (2) отрицателни и 1 положително става положително 
            //ако всички за положителни
            else if ((one < 0 && two < 0 && three > 0) ||
                     (one < 0 && three < 0 && two > 0) ||
                     (two < 0 && three < 0 && one > 0) ||
                     (one > 0 && two > 0 && three > 0))
            {
                Console.WriteLine("positive");
            }
            //ако има НЕЧЕТЕН брой отрицателни 
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}
