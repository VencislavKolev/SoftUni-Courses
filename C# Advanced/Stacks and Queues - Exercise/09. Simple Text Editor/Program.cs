using System;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> myStack = new Stack<string>();
            string text = string.Empty;
            myStack.Push(text);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs[0] == "1")
                {
                    string addText = cmdArgs[1];
                    text += addText;
                    myStack.Push(text);
                }
                else if (cmdArgs[0] == "2")
                {
                    int countCharsToRemove = int.Parse(cmdArgs[1]);
                    text = text.Substring(0, text.Length - countCharsToRemove);
                    myStack.Push(text);
                }
                else if (cmdArgs[0] == "3")
                {
                    int index = int.Parse(cmdArgs[1]) - 1;
                    char symbol = text[index];
                    Console.WriteLine(symbol);
                }
                else if (cmdArgs[0] == "4")
                {
                    myStack.Pop();
                    text = myStack.Peek();
                }
            }
        }
    }
}
