using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            while (true)
            {
                string[] input = Console.ReadLine().Split(":|:");
                if (input[0] == "Reveal")
                {
                    break;
                }
                if (input[0] == "InsertSpace")
                {
                    int index = int.Parse(input[1]);
                    message = message.Insert(index, " ");
                }
                else if (input[0] == "Reverse")
                {
                    string substring = input[1];
                    int index = message.IndexOf(substring);
                    if (message.Contains(substring))
                    {
                        string cuttedText = message.Substring(index, substring.Length);
                        message = message.Remove(index, substring.Length);
                        char[] arr = cuttedText.ToCharArray();
                        Array.Reverse(arr);
                        string reversed = new string(arr);
                        message = message.Insert(message.Length, reversed);
                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                }
                else if (input[0] == "ChangeAll")
                {
                    string substring = input[1];
                    string replacement = input[2];
                    message = message.Replace(substring, replacement);
                }
                Console.WriteLine(message);
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
