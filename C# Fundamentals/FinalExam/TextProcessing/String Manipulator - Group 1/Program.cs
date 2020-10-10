using System;

namespace String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split();
                if (inputArgs[0] == "End")
                {
                    break;
                }
                string command = inputArgs[0];
                if (command == "Translate")
                {
                    char oldChar = char.Parse(inputArgs[1]);
                    char newChar = char.Parse(inputArgs[2]);
                    text = text.Replace(oldChar, newChar);
                    Console.WriteLine(text);
                }
                else if (command == "Includes")
                {
                    string checkString = inputArgs[1];
                    bool isPresent = text.Contains(checkString);
                    Console.WriteLine(isPresent);
                }
                else if (command == "Start")
                {
                    string startString = inputArgs[1];
                    bool startsWith = text.StartsWith(startString);
                    Console.WriteLine(startsWith);
                }
                else if (command == "Lowercase")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (command == "FindIndex")
                {
                    char charr = char.Parse(inputArgs[1]);
                    int indexOf = text.LastIndexOf(charr);
                    Console.WriteLine(indexOf);
                }
                else if (command == "Remove")
                {
                    int startInd = int.Parse(inputArgs[1]);
                    int count = int.Parse(inputArgs[2]);
                    text = text.Remove(startInd, count);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
