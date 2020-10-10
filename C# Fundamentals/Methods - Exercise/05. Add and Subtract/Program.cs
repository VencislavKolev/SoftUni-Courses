using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sumOfTwo = Sum(firstNumber, secondNumber);
            int result = Substract(sumOfTwo, thirdNumber);
            Console.WriteLine(result);

        }
        static int Sum(int one, int two)
        {
            return one + two;
        }
        static int Substract(int sumOfTwoNums, int three)
        {
            return sumOfTwoNums - three;
        }
    }
}
