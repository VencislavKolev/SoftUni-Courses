using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Stack<int> myStack = new Stack<int>();
            Stack<int> mins = new Stack<int>();
            mins.Push(int.MaxValue);
            Stack<int> maxs = new Stack<int>();
            maxs.Push(int.MinValue);
            for (int i = 1; i <= lines && lines <= 105; i++)
            {
                string[] command = Console.ReadLine()
                    .Split();
                string operation = command[0];
                switch (operation)
                {
                    case "1":
                        int number = int.Parse(command[1]);
                        if (number >= 1 && number <= 109)
                        {
                            myStack.Push(number);
                        }
                        if (number > maxs.Peek())
                        {
                            maxs.Push(number);
                        }
                        if (number < mins.Peek())
                        {
                            mins.Push(number);
                        }
                        break;
                    case "2":
                        if (myStack.Any())
                        {
                            int element = myStack.Pop();
                            if (maxs.Peek() == element)
                            {
                                maxs.Pop();
                            }
                            if (mins.Peek() == element)
                            {
                                mins.Pop();
                            }
                        }
                        break;
                    case "3":
                        if (myStack.Any())
                        {
                            Console.WriteLine(maxs.Peek());
                        }; break;
                    case "4":
                        if (myStack.Any())
                        {
                            Console.WriteLine(mins.Peek());
                        }; break;
                }
            }
            Console.WriteLine(string.Join(", ", myStack));
        }
    }
}
