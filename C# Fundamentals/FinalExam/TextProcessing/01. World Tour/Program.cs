using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] inputArgs = input.Split(':');
                string command = inputArgs[0];
                if (command == "Add Stop")
                {
                    int index = int.Parse(inputArgs[1]);
                    if (index >= 0 && index < text.Length)
                    {
                        string insertString = inputArgs[2];
                        text = text.Insert(index, insertString);
                    }
                }
                else if (command == "Remove Stop")
                {
                    int startInd = int.Parse(inputArgs[1]);
                    int endInd = int.Parse(inputArgs[2]);
                    if (startInd >= 0 && endInd >= startInd &&
                        endInd < text.Length && startInd <= endInd)
                    {
                        int count = endInd - startInd + 1;
                        text = text.Remove(startInd, count);
                    }
                }
                else if (command == "Switch")
                {
                    string oldString = inputArgs[1];
                    string newString = inputArgs[2];
                    if (text.Contains(oldString))
                    {
                        text = text.Replace(oldString, newString);
                    }
                }
                Console.WriteLine(text);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
