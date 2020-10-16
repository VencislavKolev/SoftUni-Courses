using System;
using System.IO;

namespace _1.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                            Console.WriteLine(line);
                        }
                        counter++;
                    }
                }

            }
        }
    }
}
