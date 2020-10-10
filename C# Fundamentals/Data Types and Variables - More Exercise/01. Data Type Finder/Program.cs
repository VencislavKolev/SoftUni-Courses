using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string dataType = "";
            while (input != "END")
            {
                int tryInt;
                float tryFloatingPoint;
                char tryChar;
                bool tryBool;

                if (int.TryParse(input, out tryInt))
                {
                    dataType = "integer";
                }
                else if (float.TryParse(input, out tryFloatingPoint))
                {
                    dataType = "floating point";
                }
                else if (char.TryParse(input, out tryChar))
                {
                    dataType = "character";
                }
                else if (bool.TryParse(input, out tryBool))
                {
                    dataType = "boolean";
                }
                else
                {
                    dataType = "string";
                }
                Console.WriteLine($"{input} is {dataType} type");

                input = Console.ReadLine();
            }
        }
    }
}
