using System;
using System.Text;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int indexOfBegName = text.IndexOf('@');
                int indexOfEndName = text.IndexOf('|');
                string name = text.Substring(indexOfBegName + 1, indexOfEndName - (indexOfBegName + 1));
                int indexOfBegAge = text.IndexOf('#');
                int indexOfEndAge = text.IndexOf('*');
                string age = text.Substring(indexOfBegAge + 1, indexOfEndAge - (indexOfBegAge + 1));
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
