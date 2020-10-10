using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            if (dataType == "int")
            {
                int num = int.Parse(Console.ReadLine());
                ReturnAfterProcessing(num);
            }
            else if (dataType == "real")
            {
                double num = double.Parse(Console.ReadLine());
                ReturnAfterProcessing(num);
            }
            else if (dataType == "string")
            {
                string text = Console.ReadLine();
                ReturnAfterProcessing(text);
            }
        }
        static void ReturnAfterProcessing(int num)
        {
            Console.WriteLine(num * 2);
        }
        static void ReturnAfterProcessing(double num)
        {
            Console.WriteLine($"{num * 1.5:f2}");
        }
        static void ReturnAfterProcessing(string text)
        {
            Console.WriteLine($"${text}$");
        }
    }
}
