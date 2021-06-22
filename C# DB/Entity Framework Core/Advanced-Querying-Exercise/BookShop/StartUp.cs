namespace BookShop
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
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

            //----------------2. Age Restriction----------------
            //string command = Console.ReadLine().ToLower();
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));

            ////----------------3. Golden Books----------------
            //Console.WriteLine(GetGoldenBooks(db));

            ////----------------4. Books by Price----------------
            //Console.WriteLine(GetBooksByPrice(db));

            ////----------------5. Not Released In----------------
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            ////----------------6. Book Titles by Category----------------
            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, command));

            //----------------7. Released Before Date----------------
            string command = Console.ReadLine();
            Console.WriteLine(GetBooksReleasedBefore(db, command));

        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var result = context.Books
                .Where(x => x.ReleaseDate < dateTime)
                .Select(x => new
                {
                    Title = x.Title,
                    EditionType = x.EditionType,
                    Price = x.Price,
                    ReleaseDate = x.ReleaseDate
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.Title} - {item.EditionType} - ${item.Price} ");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(new char[] { ' ' }).ToArray();
            var result = context.Books
                .Where(x => x.BookCategories.Any(x => categories.Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            return String.Join(Environment.NewLine, result);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            //DateTime date = new DateTime(year, 1, 1);

            var result = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            return String.Join(Environment.NewLine, result);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var result = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in result)
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var result = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            return string.Join(Environment.NewLine, result);
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
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
