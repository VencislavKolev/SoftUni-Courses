using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string inputOne = Console.ReadLine();
            string inputTwo = Console.ReadLine();
            string result = GetMax(type, inputOne, inputTwo);
            Console.WriteLine(result);
        }
        static string GetMax(string type, string one, string two)
        {
            string output = "";
            if (type == "int")
            {
                int firstInt = int.Parse(one);
                int secondInt = int.Parse(two);
                output = Math.Max(firstInt, secondInt).ToString();
            }
            else if (type == "string" || type == "char")
            {
                string firstStr = one;
                string secondStr = two;
                if (string.CompareOrdinal(firstStr, secondStr) >= 0)
                {
                    output = firstStr;
                }
                else
                {
                    output = secondStr;
                }
            }
            return output;
        }
    }
}
