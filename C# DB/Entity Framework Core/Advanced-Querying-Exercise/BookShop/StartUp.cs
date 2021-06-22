namespace BookShop
{
    using System;
    using System.Linq;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //----------------2.Age Restriction----------------
            string command = Console.ReadLine().ToLower();
            Console.WriteLine(GetBooksByAgeRestriction(db, command));

            //----------------2.Age Restriction----------------
        }

        private static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var cmdEnum = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            string[] books = context.Books
                .Where(x => x.AgeRestriction == cmdEnum)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}
