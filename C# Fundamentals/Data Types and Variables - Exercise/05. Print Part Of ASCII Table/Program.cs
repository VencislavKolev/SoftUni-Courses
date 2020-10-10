using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            string result = "";
            for (int i = startNum; i <= endNum; i++)
            {
                result += Convert.ToChar(i) + " ";
            }
            Console.WriteLine(result);
        }
    }
}
