using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> myStack = new Stack<string>(input.Reverse());
            while (myStack.Count > 1)
            {
                int firstNumber = int.Parse(myStack.Pop());
                string operation = myStack.Pop();
                int secondNumber = int.Parse(myStack.Pop());
                int tempResult = 0;
                switch (operation)
                {
                    case "+": tempResult = firstNumber + secondNumber; break;
                    case "-": tempResult = firstNumber - secondNumber; break;
                    default:
                        break;
                }
                myStack.Push(tempResult.ToString());
            }
            int finalResult = int.Parse(myStack.Pop());
            Console.WriteLine(finalResult);
        }
    }
}
