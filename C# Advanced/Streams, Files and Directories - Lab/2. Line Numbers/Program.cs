using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    int lineNumber = 1;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        writer.WriteLine($"{lineNumber}. {line}");
                        lineNumber++;
                    }
                }
            }
        }
    }
}
