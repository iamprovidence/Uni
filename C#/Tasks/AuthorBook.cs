using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_test
{
    class Vector: IEnumerable, ICloneable, IComparable
    {
        private int[] arr;
        public int Size{get; private set;}

        public Vector(int size)
        {
            this.Size = size;
            arr = new int[size];
        }
        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }
        public double Norm
        {
            get
            {
                double res = 0;
                foreach (int el in arr)
                {
                    res += Math.Pow(el, 2);
                }
                return Math.Sqrt(res);
            }            
        }

        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < arr.Length; i+= 3)
            {
                yield return arr[i];
            }
            //yield return arr[0];
            //yield return arr[arr.Length - 1];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)arr.GetEnumerator();
        }

        public object Clone()
        {
            Vector v = (Vector)this.MemberwiseClone();

            v.arr = new int[this.arr.Length];
            for(int i = 0; i< arr.Length; ++ i)
            {
                v.arr[i] = this.arr[i];
            }

            return v;
        }

        public int CompareTo(object obj)
        {
            Vector v = obj as Vector;
            if(this.Norm < v.Norm)
            {
                return 1;
            }
            else if (this.Norm > v.Norm)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    //class Point
    //{
    //    private double x, y;
    //    public Point(int X, int Y)
    //    {
    //        this.x = X;
    //        this.y = Y;
    //    }
    //    public double distance(Point p)
    //    {
    //        return (double)Math.Sqrt(Math.Pow(p.x - this.x, 2.0) + Math.Pow(p.y - this.y, 2.0));
    //    }
    //    public override string ToString()
    //    {
    //        return $"x = {this.x} y = {this.y}";
    //    }
    //}
    //class Circle
    //{
    //    private int R;
    //    private Point center;

    //    public Circle(int R, int X, int Y)
    //    {
    //        this.R = R;
    //        center = new Point(X, Y);
    //    }
    //    public bool ContaisPoint(Point p)
    //    {
    //        return p.distance(center) < R;
    //    }

    //}

    //class Author
    //{
    //    private string name, surname;
    //    public double bonus { private set; get; }
    //    public int year { get; private set; }

    //    public Author(string n, string s, int y)
    //    {
    //        this.name = n;
    //        this.surname = s;
    //        this.year = y;
    //        this.bonus = 0;
    //    }
    //    public void reward(int pages)
    //    {
    //        this.bonus += pages * 0.5;
    //    }
    //    public override string ToString()
    //    {
    //        return $"name {name} surname {surname} bonus {bonus}";
    //    }
    //}
    //class Book
    //{
    //    private string name;
    //    private int year, pages;
    //    private Author author;
    //    public Author Author { get { return author; } }

    //    public Book(string n, int y, int p, Author a)
    //    {
    //        this.name = n;
    //        this.year = y;
    //        this.pages = p;
    //        this.author = a;
    //    }
    //    public static bool PublishedBeforeYear(Book b, int n)
    //    {
    //        return (b.year - b.author.year) < n;
    //    }
    //    public static bool ContainsPages(Book b, int p)
    //    {
    //        return b.pages > p;
    //    }
    //    public override string ToString()
    //    {
    //        return name;
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int amount_of_vector = rand.Next(10, 20);
            Vector[] VectorArr = new Vector[amount_of_vector];
            for(int i =0; i < amount_of_vector; ++i)
            {
                int vector_size = rand.Next(2, 20);
                VectorArr[i] = new Vector(vector_size);
                for(int j = 0; j < vector_size; ++j)
                {
                    VectorArr[i][j] = rand.Next(0, 100);
                }
            }
            /*
             * Vector v = new Vector(25);
            for(int i = 0; i < 25; ++ i)
            {
                v[i] = i;
            }
            Vector V = (Vector)v.Clone();
            v[0] = 15;

            foreach (int el in v)
            {
                Console.WriteLine(el);
            }
            foreach (int el in V)
            {
                Console.WriteLine(el);
            }*/
            Array.Sort(VectorArr);
            foreach(Vector el in VectorArr)
            {
                Console.WriteLine(el.Norm);
            }

            Console.ReadLine();
        }
    }
}
 