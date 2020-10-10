using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int openBrackets = 0;
            int closingBrackets = 0;
            int sum = 0;
            bool isBalanced = false;

            for (int i = 1; i <= lines; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    openBrackets++;
                    sum += openBrackets;
                    openBrackets = 0;
                    continue;
                }
                else if (input != "(")
                {
                    if (input == ")")
                    {
                        closingBrackets++;
                        sum += closingBrackets;
                        closingBrackets = 0;
                    }
                }
                if ((i == lines) && sum % 2 == 0)
                {
                    isBalanced = true;
                    break;
                }
            }
            if (isBalanced == true)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
            //int numberOfLines = int.Parse(Console.ReadLine());

            //bool isOpened = false;
            //bool isBalanced = true;

            //for (int n = 0; n < numberOfLines; n++)
            //{
            //    string input = Console.ReadLine();

            //    if (input == "(")
            //    {
            //        if (!isOpened)
            //        {
            //            isOpened = true;
            //        }
            //        else
            //        {
            //            isBalanced = false;
            //        }
            //    }

            //    if (input == ")")
            //    {
            //        if (isOpened)
            //        {
            //            isOpened = false;
            //        }
            //        else
            //        {
            //            isBalanced = false;
            //        }
            //    }
            //}
            //if (isBalanced && !isOpened)
            //{
            //    Console.WriteLine("BALANCED");
            //}
            //else
            //{
            //    Console.WriteLine("UNBALANCED");
            //}
        }
    }
}
