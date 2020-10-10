using System;
using System.Linq;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separator = new char[]
            {
                ':','\\'
            }.ToArray();
            string[] text = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] fileExt = text.Last().Split('.');
            Console.WriteLine("File name: " + fileExt[0]);
            Console.WriteLine("File extension: " + fileExt[1]);
        }
    }
}
