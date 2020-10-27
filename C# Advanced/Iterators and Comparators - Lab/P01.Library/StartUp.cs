using System;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Console.WriteLine(bookOne);
            Console.WriteLine(bookTwo);
            Console.WriteLine(bookThree);
            Console.WriteLine();
            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);
            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }
        }
    }
}
