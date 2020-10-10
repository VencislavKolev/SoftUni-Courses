using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
            while (inputNumber != "END")
            {
                Console.WriteLine(IsPalindrome(inputNumber)
                    .ToString().ToLower());
                inputNumber = Console.ReadLine();
            }
            static bool IsPalindrome(string number)
            {
                //53135 е с дължина 5,броят итерации е 2
                //сравняваме първия с последния елемент
                //втория с предпоследния и тн
                //когато дължината е НЕЧЕТНА средния елемент е еднакъв
                for (int i = 0; i < number.Length / 2; i++)
                {
                    if (number[i] != number[number.Length - 1 - i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
