
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace IteratorsAndComparators
{
    public class Book
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public IReadOnlyList<string> Authors { get; set; }
        public override string ToString()
        {
            return $"{this.Title} {this.Year} {string.Join(", ",this.Authors)}";
        }
    }
}
