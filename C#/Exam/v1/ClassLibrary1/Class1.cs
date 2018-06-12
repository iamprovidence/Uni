using System;

namespace ClassLibrary1
{
    public class PropertyChanged : EventArgs
    {
        private string message;

        public PropertyChanged(string propertyName, string oldValue, string newValue)
        {
            message = $"Property named \'{propertyName}\' change his value from \'{oldValue}\' to \'{newValue}\'";
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }
    }
    public class Book : IComparable<Book>, ICloneable<Book>
    {
        public event EventHandler<PropertyChanged> propertyChanged;
        protected string name;
        protected int amountOfPages;
        public Book()
        {
            name = String.Empty;
            amountOfPages = int.MinValue;
        }

        public Book(string[] data)
        {
            if (data.Length > 2) throw new ArgumentException("Too many argument");
            else if (data.Length < 2) throw new ArgumentException("Too few argument");

            name = data[0];
            amountOfPages = int.Parse(data[1]);

        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name.CompareTo(value) != 0)
                    propertyChanged?.Invoke(this, new PropertyChanged(nameof(Name), Name, value));
                name = value;
            }
        }

        public int AmountOfPages
        {
            get
            {
                return amountOfPages;
            }

            set
            {
                if (amountOfPages.CompareTo(value) != 0)
                    propertyChanged?.Invoke(this, new PropertyChanged(nameof(AmountOfPages), AmountOfPages.ToString(), value.ToString()));
                amountOfPages = value;
            }
        }
        public override string ToString()
        {
            return String.Concat("Book named ", name, " amount of pages ", amountOfPages);
        }
        public virtual string ToFile()
        {
            return $"S*{name} {amountOfPages}";
        }

        public virtual int CompareTo(Book other)
        {
            int nameCompare = this.name.CompareTo(other.name);
            if (nameCompare == 0) return this.amountOfPages.CompareTo(other.amountOfPages);
            else return nameCompare;
        }

        public Book Clone()
        {
            return this.MemberwiseClone() as Book;
        }

        public static Book operator +(Book l, Book r)
        {
            return new Book()
            {
                name = l.name + r.name,
                amountOfPages = l.amountOfPages + r.amountOfPages
            };
        }
    }

    class ScienceBook : Book, IComparable<ScienceBook>, ICloneable<ScienceBook>
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event EventHandler<PropertyChanged> propertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        private string author;
        public ScienceBook()
        {
            name = String.Empty;
            author = String.Empty;
            amountOfPages = int.MinValue;
        }

        public ScienceBook(string[] data)
        {
            if (data.Length > 3) throw new ArgumentException("Too many argument");
            else if (data.Length < 3) throw new ArgumentException("Too few argument");

            name = data[0];
            amountOfPages = int.Parse(data[1]);
            author = data[2];
        }


        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                if (author.CompareTo(value) != 0)
                    propertyChanged?.Invoke(this, new PropertyChanged(nameof(Author), Author, value));
                author = value;
            }
        }

        public override string ToString()
        {
            return String.Concat("ScienveBook named ", name, " amount of pages ", amountOfPages, " writen by ", author);
        }

        public virtual int CompareTo(ScienceBook other)
        {
            int nameCompare = this.name.CompareTo(other.name);
            int authorCompare = this.author.CompareTo(other.author);
            if (nameCompare == 0)
            {
                if (authorCompare == 0)
                {
                    return this.amountOfPages.CompareTo(other.amountOfPages);
                }
                else return authorCompare;
            }
            else return nameCompare;
        }
        public override string ToFile()
        {
            return $"SB*{name} {amountOfPages} {author}";
        }

        ScienceBook ICloneable<ScienceBook>.Clone()
        {
            return this.MemberwiseClone() as ScienceBook;
        }

        public static ScienceBook operator +(ScienceBook l, ScienceBook r)
        {
            return new ScienceBook()
            {
                name = l.name + r.name,
                amountOfPages = l.amountOfPages + r.amountOfPages,
                author = String.Concat(l.author, " and ", r.author)
            };
        }
    }
}
