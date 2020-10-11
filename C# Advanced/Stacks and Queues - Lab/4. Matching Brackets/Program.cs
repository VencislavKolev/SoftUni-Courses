using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<int> myStack = new Stack<int>();
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                if (symbol == '(')
                {
                    myStack.Push(i);
                }
                else if (symbol == ')')
                {
                    int indexOfOpeneningBracket = myStack.Pop();
                    string result = text.Substring
                        (indexOfOpeneningBracket,
                        i - indexOfOpeneningBracket + 1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
