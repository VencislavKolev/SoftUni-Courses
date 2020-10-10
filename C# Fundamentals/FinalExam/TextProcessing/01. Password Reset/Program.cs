using System;
using System.Text;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Done")
                {
                    break;
                }
                if (input[0] == "TakeOdd")
                {
                    StringBuilder newPassword = new StringBuilder();
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        newPassword.Append(password[i]);
                    }
                    password = newPassword.ToString();
                    Console.WriteLine(password);
                }
                else if (input[0] == "Cut")
                {
                    int index = int.Parse(input[1]);
                    int length = int.Parse(input[2]);
                    //string substring = text.Substring(index, length);
                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if (input[0] == "Substitute")
                {
                    string substring = input[1];
                    string substitute = input[2];
                    if (password.Contains(substring))
                    {
                        while (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                        }
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
