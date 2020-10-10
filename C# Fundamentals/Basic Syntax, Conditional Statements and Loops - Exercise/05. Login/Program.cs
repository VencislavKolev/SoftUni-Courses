using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string reverseUsername = "";
            string userInput = "";
            int counter = 0;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                reverseUsername += username[i];

            }
            while ((userInput = Console.ReadLine()) != reverseUsername)
            {
                counter++;
                if (userInput != reverseUsername && counter <= 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }

                else
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
            }
            Console.WriteLine($"User {username} logged in.");
        }
    }
}
