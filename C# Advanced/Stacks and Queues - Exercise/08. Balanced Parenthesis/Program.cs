using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Четем следващата скоба или отиваме на т. 4, ако сме прочели всичко
            //2.Ако е отваряща(, [, {
            //-слагаме я в стека и отиваме на т. 1
            //3.Ако е затваряща: ), ], }:
            //-ако стека е празен->невалиден израз("NO")
            //-вадим последната скоба от стека и гледаме дали е отваряща от правилния тип:
            //(за), [за] и { за }. Ако не съвпада->невалиден израз("NO"), иначе отиваме на т. 1
            //4.Проверяваме дали има нещо в стека:
            //-ако има -> невалиден израз("NO")
            //-ако е празен->изразът е валиден("YES")
            char[] openingParentheses = new char[]
            {
                '{','(','['
            };
            char[] closingParentheses = new char[]
           {
                 '}',')',']'
           };
            string input = Console.ReadLine();
            Stack<char> openingStack = new Stack<char>();
            bool isBalanced = true;
            for (int i = 0; i < input.Length; i++)
            {
                char currSymb = input[i];
                if (openingParentheses.Contains(currSymb))
                {
                    openingStack.Push(currSymb);
                }
                else if (closingParentheses.Contains(currSymb))
                {
                    if (openingStack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    else
                    {
                        char openingBracket = openingStack.Pop();
                        if ((openingBracket == '{' && currSymb != '}') ||
                            (openingBracket == '[' && currSymb != ']') ||
                            (openingBracket == '(' && currSymb != ')'))
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
