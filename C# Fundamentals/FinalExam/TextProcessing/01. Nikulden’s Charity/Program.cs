using System;
using System.Linq;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Finish")
            {
                string[] command = input.Split();
                if (command[0] == "Replace")
                {
                    char currChar = char.Parse(command[1]);
                    char newChar = char.Parse(command[2]);
                    text = text.Replace(currChar, newChar);
                    Console.WriteLine(text);
                }
                else if (command[0] == "Cut")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    if (!IsValidIndex(text, startIndex, endIndex))
                    {
                        Console.WriteLine("Invalid indexes!");
                        continue;
                    }
                    string removeSubstring = text.Substring(startIndex, endIndex - startIndex + 1);
                    text = text.Replace(removeSubstring, "");
                    Console.WriteLine(text);
                }
                else if (command[0] == "Make")
                {
                    if (command[1] == "Upper")
                    {
                        text = text.ToUpper();
                    }
                    else if (command[1] == "Lower")
                    {
                        text = text.ToLower();
                    }
                    Console.WriteLine(text);
                }
                else if (command[0] == "Check")
                {
                    string checkString = command[1];
                    if (text.Contains(checkString))
                    {
                        Console.WriteLine($"Message contains {checkString}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {checkString}");
                    }
                }
                else if (command[0] == "Sum")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    if (!IsValidIndex(text, startIndex, endIndex))
                    {
                        Console.WriteLine("Invalid indexes!");
                        continue;
                    }
                    string sumSubstring = text.Substring(startIndex, endIndex - startIndex + 1);
                    int sum = 0;
                    for (int i = 0; i < sumSubstring.Length; i++)
                    {
                        sum += (int)sumSubstring[i];
                    }
                    //for (int i = startIndex; i <= endIndex; i++)
                    //{
                    //    sum += (int)text[i];
                    //}
                    Console.WriteLine(sum);

                }
            }
        }
        static bool IsValidIndex(string text, int startIndex, int endIndex)
        {
            bool isValidIndex = false;
            if ((startIndex >= 0 && endIndex >= startIndex && endIndex < text.Length))
            {
                isValidIndex = true;
            }
            return isValidIndex;
        }
    }
}
