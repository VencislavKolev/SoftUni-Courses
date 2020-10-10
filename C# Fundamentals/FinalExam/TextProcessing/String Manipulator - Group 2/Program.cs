using System;
using System.Linq;

namespace String_Manipulator___Group_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split();
                if (inputArgs[0] == "Done")
                {
                    break;
                }
                string command = inputArgs[0];
                if (command == "Change")
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
                else if (command == "End")
                {
                    string endString = inputArgs[1];
                    bool endsWith = text.EndsWith(endString);
                    Console.WriteLine(endsWith);
                }
                else if (command == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (command == "FindIndex")
                {
                    char charr = char.Parse(inputArgs[1]);
                    int indexOf = text.IndexOf(charr);
                    Console.WriteLine(indexOf);
                }
                else if (command == "Cut")
                {
                    int startInd = int.Parse(inputArgs[1]);
                    int length = int.Parse(inputArgs[2]);
                    text = text.Substring(startInd, length);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
