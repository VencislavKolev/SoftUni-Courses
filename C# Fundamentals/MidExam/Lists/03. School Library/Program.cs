using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine().Split('&').ToList();
            string input = "";
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] tokens = input.Split(" | ");
                string action = tokens[0];
                string bookName = string.Empty;
                if (action == "Add Book")
                {
                    bookName = tokens[1];
                    if (!books.Contains(bookName))
                    {
                        books.Insert(0, bookName);
                    }
                }
                else if (action == "Take Book")
                {
                    bookName = tokens[1];
                    if (books.Contains(bookName))
                    {
                        books.Remove(bookName);
                    }
                }
                else if (action == "Swap Books")
                {
                    bookName = tokens[1];
                    string secondBook = tokens[2];
                    if (books.Contains(bookName) && books.Contains(secondBook))
                    {
                        int firstBookIndex = books.IndexOf(bookName);
                        int secondBookIndex = books.IndexOf(secondBook);
                        string temp = bookName;
                        books[firstBookIndex] = books[secondBookIndex];
                        books[secondBookIndex] = temp;
                        //books.RemoveAt(secondBookIndex);
                        //books.Insert(secondBookIndex, bookName);
                        //books.Remove(bookName);
                        //books.Insert(firstBookIndex, secondBook);
                    }
                }
                else if (action == "Insert Book")
                {
                    bookName = tokens[1];
                    books.Add(bookName);
                }
                else if (action == "Check Book")
                {
                    int index = int.Parse(tokens[1]);
                    if (index >= 0 && index < books.Count)
                    {
                        Console.WriteLine(books[index]);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", books));
        }
    }
}
