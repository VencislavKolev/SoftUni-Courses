
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }
        public string Title { get; set; }
        public int Year { get; set; }
        // public List<string> Authors{ get; }
        public IReadOnlyList<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            int nameComparison = this.Year.CompareTo(other.Year);
            //int nameComparison = other.Year.CompareTo(this.Year); Sort by descending year!1
            if (nameComparison == 0)
            {
                nameComparison = this.Title.CompareTo(other.Title);
            }
            return nameComparison;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
