using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split();
                if (inputArgs[0] == "Complete")
                {
                    break;
                }
                string command = inputArgs[0];
                if (command == "Make")
                {
                    if (inputArgs[1] == "Upper")
                    {
                        text = text.ToUpper();
                    }
                    else if (inputArgs[1] == "Lower")
                    {
                        text = text.ToLower();
                    }
                    Console.WriteLine(text);
                }
                else if (command == "GetDomain")
                {
                    int count = int.Parse(inputArgs[1]);
                    //if count<text.len
                    char[] lastChars = text.TakeLast(count).ToArray();
                    Console.WriteLine(string.Join("", lastChars));
                }
                else if (command == "GetUsername")
                {
                    int indexOfClomba = text.IndexOf("@");
                    string message = string.Empty;
                    if (indexOfClomba != -1)
                    {
                        string username = text.Substring(0, indexOfClomba);
                        message = username;
                    }
                    else
                    {
                        message = $"The email {text} doesn't contain the @ symbol.";
                    }
                    Console.WriteLine(message);
                }
                else if (command == "Replace")
                {
                    char oldChar = char.Parse(inputArgs[1]);
                    text = text.Replace(oldChar, '-');
                    Console.WriteLine(text);
                }
                else if (command == "Encrypt")
                {
                    List<int> asciiValues = new List<int>();
                    for (int i = 0; i < text.Length; i++)
                    {
                        asciiValues.Add(text[i]);
                    }
                    Console.WriteLine(string.Join(" ", asciiValues));
                }
            }
        }
    }
}
