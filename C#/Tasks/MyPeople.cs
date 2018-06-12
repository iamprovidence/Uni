using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyPeople
{
    class Author
    {
        private string name, surname;
        public double bonus { private set; get; }
        public int year { get; private set; }

        public Author(string n, string s, int y)
        {
            this.name = n;
            this.surname = s;
            this.year = y;
            this.bonus = 0;
        }
        public void reward(int pages)
        {
            this.bonus += pages * 0.5;
        }
        public override string ToString()
        {
            return $"name {name} surname {surname} bonus {bonus}";
        }
    }
    class Book
    {
        private string name;
        private int year, pages;
        private Author author;
        public Author Author { get { return author; } }

        public Book(string n, int y, int p, Author a)
        {
            this.name = n;
            this.year = y;
            this.pages = p;
            this.author = a;
        }
        public static bool PublishedBeforeYear(Book b, int n)
        {
            return (b.year - b.author.year) < n;
        }
        public static bool ContainsPages(Book b, int p)
        {
            return b.pages > p;
        }
        public override string ToString()
        {
            return name;
        }
    }
}