using System;

namespace Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split();
                if (inputArgs[0] == "Sign" && inputArgs[1] == "up")
                {
                    break;
                }
                string command = inputArgs[0];
                if (command == "Case")
                {
                    if (inputArgs[1] == "lower")
                    {
                        username = username.ToLower();
                    }
                    else
                    {
                        username = username.ToUpper();
                    }
                    Console.WriteLine(username);
                }
                else if (command == "Reverse")
                {
                    int startInd = int.Parse(inputArgs[1]);
                    int endInd = int.Parse(inputArgs[2]);
                    if (startInd >= 0 && endInd >= startInd && endInd < username.Length)
                    {
                        string reversedSubstring = username.Substring(startInd, (endInd - startInd + 1));
                        char[] chars = reversedSubstring.ToCharArray();
                        Array.Reverse(chars);
                        reversedSubstring = new string(chars);
                        Console.WriteLine(reversedSubstring);
                    }
                }
                else if (command == "Cut")
                {
                    string substringToCut = inputArgs[1];
                    if (username.Contains(substringToCut))
                    {
                        // username = username.Replace(substringToCut, "");
                        username = username.Remove(username.IndexOf(substringToCut), substringToCut.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substringToCut}.");
                    }
                }
                else if (command == "Replace")
                {
                    char charToReplace = char.Parse(inputArgs[1]);
                    username = username.Replace(charToReplace, '*');
                    Console.WriteLine(username);
                }
                else if (command == "Check")
                {
                    char checkChar = char.Parse(inputArgs[1]);
                    string message = string.Empty;
                    if (username.Contains(checkChar))
                    {
                        message = "Valid";
                    }
                    else
                    {
                        message = $"Your username must contain {checkChar}.";
                    }
                    Console.WriteLine(message);
                }
            }
        }
    }
}
