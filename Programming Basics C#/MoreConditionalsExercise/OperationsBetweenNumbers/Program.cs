using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string operatorSymbol = Console.ReadLine();
            double result = 0;

            if (operatorSymbol=="+" || operatorSymbol == "-" || operatorSymbol == "*")
            {
                switch (operatorSymbol)
                {
                    case "+":result = num1 + num2;break;
                    case "-":result = num1 - num2;break;
                    case "*":result = num1 * num2;break;
                }
                string evenOrOdd = "";
                if (result%2==0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }
                Console.WriteLine($"{num1} {operatorSymbol} {num2} = {result} - {evenOrOdd}");
                //bool isEven = result % 2 == 0;
                //if (isEven)
                //{
                //    string even = "even";
                //    Console.WriteLine($"{num1} {operatorSymbol} {num2} = {result} - {even}");
                //}
                //else if (!isEven)
                //{
                //    string odd = "odd";
                //    Console.WriteLine($"{num1} {operatorSymbol} {num2} = {result} - {odd}");
                //}
            }
            else if (operatorSymbol=="/" && num2!=0)
            {
                result = num1 * 1.0 / num2;
                Console.WriteLine($"{num1} / {num2} = {result:f2}");
            }
            else if (operatorSymbol == "%" && num2!=0)
            {
                result = num1 % num2;
                Console.WriteLine($"{num1} % {num2} = {result}");
            }
            else if ((operatorSymbol == "/" || operatorSymbol == "%") && num2==0)
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
            }
        }
    }
}
