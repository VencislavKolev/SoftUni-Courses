namespace BookShop
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using BookShop.Models.Enums;
    using Data;

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

            ////----------------7. Released Before Date----------------
            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, command));

            ////----------------8. Author Search----------------
            //string command = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, command));

            ////----------------9. Book Search----------------
            //string command = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, command));

            ////----------------10. Book Search by Author----------------
            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db, command));

            ////----------------11. Count Books----------------
            //int length = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db, length));

            ////----------------12. Total Book Copies----------------
            //Console.WriteLine(CountCopiesByAuthor(db));

            //----------------13. Profit by Category----------------
            Console.WriteLine(GetTotalProfitByCategory(db));

        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context.Categories
                .Select(x => new
                {
                    Categorie = x.Name,
                    Profit = x.CategoryBooks.Sum(x => x.Book.Copies * x.Book.Price)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Categorie)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var item in result)
            {
                sb.AppendLine($"{item.Categorie} ${item.Profit:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var result = context.Authors
                .Select(x => new
                {
                    Author = x.FirstName + " " + x.LastName,
                    Copies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var item in result)
            {
                sb.AppendLine($"{item.Author} - {item.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books
                .Count(x => x.Title.Length > lengthCheck);

            return count;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var result = context.Books
                .Where(x => x.Author.LastName.StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    Title = x.Title,
                    Author = String.Join(" ", x.Author.FirstName, x.Author.LastName)
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in result)
            {
                sb.AppendLine($"{book.Title} ({book.Author})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var result = context.Books
                .Where(x => x.Title.Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            return String.Join(Environment.NewLine, result);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var author in result)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }
            return sb.ToString().TrimEnd();
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
