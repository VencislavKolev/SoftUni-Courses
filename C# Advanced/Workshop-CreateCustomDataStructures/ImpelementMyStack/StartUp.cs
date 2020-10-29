using System;
using System.Collections.Generic;
using System.Linq;

namespace ImpelementMyStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
           
            MyStack<int> myStack = new MyStack<int>();
            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }
            myStack.ForEach(n => Console.WriteLine(n * 5));
        }
    }
}
