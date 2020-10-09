using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            int bookstoreCapacity = int.Parse(Console.ReadLine());
            string currentBookName = Console.ReadLine();
            int counter = 0;
            while (bookName != currentBookName)
            {
                counter++;
                if (counter == bookstoreCapacity)
                {
                    break;
                }
                currentBookName = Console.ReadLine();
            }
            if (currentBookName == bookName)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }

        }
    }
}
