using System;
using System.Collections.Generic;

namespace P03.Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<string> myStack = new CustomStack<string>();
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "END")
            {
                string cmd = input[0];
                switch (cmd)
                {
                    case "Push":
                        for (int i = 1; i < input.Length; i++)
                        {
                            string currElement = input[i];
                            myStack.Push(currElement);
                        };
                        break;
                    case "Pop":
                        myStack.Pop();
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
