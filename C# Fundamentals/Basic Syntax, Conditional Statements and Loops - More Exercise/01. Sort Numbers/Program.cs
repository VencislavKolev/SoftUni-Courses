using System;

namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int number1 = int.Parse(Console.ReadLine());
            //int number2 = int.Parse(Console.ReadLine());
            //int number3 = int.Parse(Console.ReadLine());

            //if (number1>=number2 && number1>=number3)
            //{
            //    Console.WriteLine(number1);
            //    if (number2>=number3)
            //    {
            //        Console.WriteLine(number2);
            //        Console.WriteLine(number3);
            //    }
            //    else
            //    {
            //        Console.WriteLine(number3);
            //        Console.WriteLine(number2);
            //    }
            //}
            //else if (number2 >= number1 && number2 >=number3)
            //{
            //    Console.WriteLine(number2);
            //    if (number1 >= number3)
            //    {
            //        Console.WriteLine(number1);
            //        Console.WriteLine(number3);
            //    }
            //    else
            //    {
            //        Console.WriteLine(number3);
            //        Console.WriteLine(number1);
            //    }
            //}
            //if (number3 >= number1 && number3 >= number2)
            //{
            //    Console.WriteLine(number3);
            //    if (number2 >= number1)
            //    {
            //        Console.WriteLine(number2);
            //        Console.WriteLine(number1);
            //    }
            //    else
            //    {
            //        Console.WriteLine(number1);
            //        Console.WriteLine(number2);
            //    }
            //}
            int number1 = int.MinValue;
            int number2 = int.MinValue;
            int number3 = int.MinValue;

            for (int i = 1; i <= 3; i++)
            {
                int numberToCheck = int.Parse(Console.ReadLine());
                if (numberToCheck > number1)
                {
                    number3 = number2;
                    number2 = number1;
                    number1 = numberToCheck;
                }
                else if (numberToCheck > number2)
                {
                    number3 = number2;
                    number2 = numberToCheck;
                }
                else if (numberToCheck > number3)
                {
                    number3 = numberToCheck;
                }

            }
            Console.WriteLine(number1);
            Console.WriteLine(number2);
            Console.WriteLine(number3);
        }
    }
}
