using System;

namespace _02._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string enterPassword = Console.ReadLine();
            while (enterPassword!=password)
            {
                enterPassword = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {username}!");
        }
    }
}
