using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> myStack = new Stack<char>();
            foreach (var symbol in input)
            {
                myStack.Push(symbol);
            }
            StringBuilder sb = new StringBuilder();
            while (myStack.Any())
            {
                sb.Append(myStack.Pop());
                // Console.Write(myStack.Pop());
            }
            Console.WriteLine(sb);
        }
    }
}
