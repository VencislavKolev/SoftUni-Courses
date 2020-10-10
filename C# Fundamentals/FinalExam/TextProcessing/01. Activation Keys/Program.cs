using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(">>>");
                if (inputArgs[0] == "Generate")
                {
                    break;
                }
                if (inputArgs[0] == "Contains")
                {
                    string substring = inputArgs[1];
                    if (rawKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (inputArgs[0] == "Flip")
                {
                    int startIndex = int.Parse(inputArgs[2]);
                    int endIndex = int.Parse(inputArgs[3]);
                    string substring = rawKey.Substring(startIndex, endIndex - startIndex);
                    if (inputArgs[1] == "Upper")
                    {
                        rawKey = rawKey.Replace(substring, substring.ToUpper());
                    }
                    else if (inputArgs[1] == "Lower")
                    {
                        rawKey = rawKey.Replace(substring, substring.ToLower());
                    }
                    Console.WriteLine(rawKey);
                }
                else if (inputArgs[0] == "Slice")
                {
                    int startIndex = int.Parse(inputArgs[1]);
                    int endIndex = int.Parse(inputArgs[2]);
                    rawKey = rawKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(rawKey);
                }
            }
            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}
