using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyMath
{
    class Point
    {
        private double x, y;
        public Point(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }
        public double distance(Point p)
        {
            return (double)Math.Sqrt(Math.Pow(p.x - this.x, 2.0) + Math.Pow(p.y - this.y, 2.0));
        }
        public override string ToString()
        {
            return $"x = {this.x} y = {this.y}";
        }
    }

    class Circle
    {
        private int R;
        private Point center;

        public Circle(int R, int X, int Y)
        {
            this.R = R;
            center = new Point(X, Y);
        }
        public bool ContaisPoint(Point p)
        {
            return p.distance(center) < R;
        }

    }

    class Matrix : IEnumerable, ICloneable, IComparable, IFormattable
    {
        int[,] basic;
        int size;

        public Matrix() : this(0)
        {
        }
        public Matrix(int size)
        {
            this.size = size;
            basic = new int[size, size];
        }
        public Matrix(int[,] arr)
        {
            if (arr.GetLength(0) != arr.GetLength(1)) throw new Exception("Not Square");

            this.size = arr.GetLength(0);
            basic = (int[,])arr.Clone();
        }

        public double Norm
        {
            get
            {
                double norm = 0;
                foreach (int el in basic)
                {
                    norm += Math.Pow(el, 2);
                }
                return Math.Sqrt(norm);
            }
        }
        public int Size { get { return size; } }

        public int this[int i, int j]
        {
            get { return basic[i, j]; }
            set { basic[i, j] = value; }
        }

        public static Matrix operator +(Matrix l, Matrix r)
        {
            if (l.size != r.size) throw new Exception("Not the same size");

            Matrix res = new Matrix(l.size);
            for (int i = 0; i < res.size; ++i)
            {
                for (int j = 0; j < res.size; ++j)
                {
                    res[i, j] = l[i, j] + r[i, j];
                }
            }
            return res;
        }
        public static Matrix operator -(Matrix l, Matrix r)
        {
            if (l.size != r.size) throw new Exception("Not the same size");

            Matrix res = new Matrix(l.size);
            for (int i = 0; i < res.size; ++i)
            {
                for (int j = 0; j < res.size; ++j)
                {
                    res[i, j] = l[i, j] - r[i, j];
                }
            }
            return res;
        }
        public static Matrix operator +(int l, Matrix r)
        {
            Matrix res = new Matrix(r.size);
            for (int i = 0; i < res.size; ++i)
            {
                res[i, i] += l;
            }
            return res;
        }
        public static Matrix operator -(Matrix l, int r)
        {
            return r + l;
        }
        public static Matrix operator *(int l, Matrix r)
        {
            Matrix res = new Matrix(r.size);
            for (int i = 0; i < res.size; ++i)
            {
                for (int j = 0; j < r.size; ++j)
                {
                    res[i, j] *= l;
                }
            }
            return res;
        }
        public static Matrix operator *(Matrix l, int r)
        {
            return r * l;
        }
        public static Matrix operator *(Matrix l, Matrix r)
        {
            if (l.size != r.size) throw new Exception("Not the same size");

            Matrix res = new Matrix(l.size);

            for (int i = 0; i < l.size; i++)
            {
                for (int j = 0; j < l.size; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < l.size; k++)
                    {
                        sum += l[i, k] * r[k, j];
                    }
                    res[i, j] = sum;
                }
            }
            return res;
        }
        public static Matrix operator ++(Matrix m)
        {
            Matrix inc = new Matrix(m.size);
            for (int i = 0; i < inc.size; ++i)
            {
                inc[i, i] = 1;
            }
            return m + inc;
        }
        public static Matrix operator --(Matrix m)
        {
            Matrix inc = new Matrix(m.size);
            for (int i = 0; i < inc.size; ++i)
            {
                inc[i, i] = 1;
            }
            return m - inc;
        }

        public override bool Equals(object obj)
        {
            Matrix m = obj as Matrix;
            if (this.size != m.size) return false;

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (this.basic[i, j] != m.basic[i, j]) return false;
                }
            }

            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            string m = "Matrix\n";
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    m += basic[i, j].ToString() + '\t';
                }
                m += '\n';
            }
            return m + '\n';
        }

        public int CompareTo(object obj)
        {
            Matrix m = obj as Matrix;

            if (this.Norm > m.Norm) return 1;
            else if (this.Norm < m.Norm) return -1;
            else return 0;
        }
        public static bool operator ==(Matrix l, Matrix r)
        {
            return l.Equals(r);
        }
        public static bool operator !=(Matrix l, Matrix r)
        {
            return !l.Equals(r);
        }
        public static bool operator >(Matrix l, Matrix r)
        {
            return l.CompareTo(r) > 0;
        }
        public static bool operator <(Matrix l, Matrix r)
        {
            return l.CompareTo(r) < 0;
        }
        public static bool operator >=(Matrix l, Matrix r)
        {
            return !(l < r);
        }
        public static bool operator <=(Matrix l, Matrix r)
        {
            return !(l > r);
        }

        public object ShallowCopy()
        {
            return (Matrix)this.MemberwiseClone();
        }
        public object DeepCopy()
        {
            Matrix m = new Matrix(this.size);
            //m.basic = (int[,])this.basic.Clone();
            m.basic = new int[size, size];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    m.basic[i, j] = this.basic[i, j];
                }
            }

            return m;
        }
        public object Clone()
        {
            return new Matrix(this.basic);
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.size; ++i)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < size; ++j)
                    {
                        yield return basic[i, j];
                    }
                }
                else
                {
                    for (int j = size - 1; j >= 0; --j)
                    {
                        yield return basic[i, j];
                    }
                }
            }
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format.Equals(null)) return this.ToString();

            switch (format.ToUpper())
            {
                case "STYLISH":
                    {
                        StringBuilder m1 = new StringBuilder("***\tMatrix\t***\n");
                        for (int i = 0; i < size; ++i)
                        {
                            for (int j = 0; j < size; ++j)
                            {
                                m1.Append(basic[i, j].ToString() + '\t');
                            }
                            m1.Append(Environment.NewLine);
                        }
                        return m1.Append(Environment.NewLine).ToString();
                    }
                case "SNAKE":
                    {
                        string m2 = "***\tMatrix\t***\n";
                        foreach (int el in this)
                        {
                            m2 += el.ToString() + ' ';
                        }
                        return m2 + '\n';
                    }
                case "ROW":
                    {
                        string m3 = "Matrix:\t";
                        foreach (int el in this)
                        {
                            m3 += el.ToString() + ' ';
                        }
                        return m3 + '\n';
                    }

                default: return this.ToString();
            }
        }
    }

    class Vector : IEnumerable, ICloneable, IComparable, IFormattable
    {
        int[] basic;
        int size;
        public int Size { get { return size; } }

        public Vector() : this(0)
        {
        }
        public Vector(int size)
        {
            this.size = size;
            basic = new int[size];

        }
        public Vector(int[] arr)
        {
            this.size = arr.Length;
            basic = (int[])arr.Clone();
        }

        public double GetNorm()
        {
            double norm = 0;
            for (int i = 0; i < size; ++i)
            {
                norm += Math.Pow(basic[i], 2);
            }

            return Math.Sqrt(norm);
        }
        public int GetSum()
        {
            return basic.Sum();
        }

        public int this[int i]
        {
            get { return basic[i]; }
            set { basic[i] = value; }
        }

        public static Vector operator +(Vector l, Vector r)
        {
            if (l.size != r.size) throw new Exception("Not the same size");

            Vector res = new Vector(l.size);

            for (int i = 0; i < l.size; ++i)
            {
                res[i] = l[i] + r[i];
            }
            return res;
        }
        public static Vector operator -(Vector l, Vector r)
        {
            if (l.size != r.size) throw new Exception("Not the same size");

            Vector res = new Vector(l.size);

            for (int i = 0; i < l.size; ++i)
            {
                res[i] = l[i] - r[i];
            }
            return res;
        }
        public static Vector operator +(int l, Vector r)
        {
            Vector res = new Vector(r.size);

            for (int i = 0; i < r.size; ++i)
            {
                res[i] = l + r[i];
            }
            return res;
        }
        public static Vector operator +(Vector l, int r)
        {
            return r + l;
        }
        public static Vector operator -(Vector l, int r)
        {
            Vector res = new Vector(l.size);

            for (int i = 0; i < l.size; ++i)
            {
                res[i] = l[i] - r;
            }
            return res;
        }
        public static Vector operator -(int l, Vector r)
        {
            return r - l;
        }
        public static Vector operator *(int l, Vector r)
        {
            Vector res = new Vector(r.size);

            for (int i = 0; i < r.size; ++i)
            {
                res[i] = l * r[i];
            }
            return res;
        }
        public static Vector operator *(Vector l, int r)
        {
            return r * l;
        }
        public static Vector operator *(Vector l, Vector r)
        {
            Vector res = new Vector(l.size);

            for (int i = 0; i < res.size; ++i)
            {
                res[i] = l[i] * r[i];
            }

            return res;
        }
        public static Vector operator *(Matrix l, Vector r)
        {
            if (l.Size != r.size) throw new Exception("Not the same size");

            Vector res = new Vector(r.size);

            for (int i = 0; i < r.size; ++i)
            {
                int sum = 0;
                for (int j = 0; j < r.size; ++j)
                {
                    sum += l[i, j] * r[j];
                }
                res[i] = sum;
            }
            return res;
        }
        public static Vector operator ++(Vector m)
        {
            Vector inc = new Vector(m.size);
            for (int i = 0; i < m.size; ++i)
            {
                inc[i] = 1;
            }
            return m + inc;
        }
        public static Vector operator --(Vector m)
        {
            Vector dec = new Vector(m.size);
            for (int i = 0; i < m.size; ++i)
            {
                dec[i] = 1;
            }
            return m - dec;
        }

        public override bool Equals(object obj)
        {
            Vector e = obj as Vector;
            if (e.size != this.size) return false;

            for (int i = 0; i < size; ++i)
            {
                if (basic[i] != e[i]) return false;
            }

            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder("Vector:\t");
            for (int i = 0; i < size; ++i)
            {
                s.Append(basic[i].ToString() + ' ');
            }
            return s.ToString();
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format.Equals(null) || !Regex.IsMatch(format, "[NS(SU)(EL)]{1}", RegexOptions.IgnoreCase)) return this.ToString();

            StringBuilder build = new StringBuilder("* Vector:");
            if (Regex.IsMatch(format, "N{1}", RegexOptions.IgnoreCase))
            {
                build.AppendFormat("\nNorm: {0:#.00}", this.GetNorm());
            }
            if (Regex.IsMatch(format, "S{1}", RegexOptions.IgnoreCase))
            {
                build.AppendFormat("\nSize: {0}", this.Size);
            }
            if (Regex.IsMatch(format, "(SU){1}", RegexOptions.IgnoreCase))
            {
                build.AppendFormat("\nSum: {0}", this.GetSum());
            }
            if (Regex.IsMatch(format, "(el){1}", RegexOptions.IgnoreCase))
            {
                build.Append("\nEl: ");
                foreach (int el in basic)
                {
                    build.Append(el.ToString() + ' ');
                }
            }
            return build.Append(Environment.NewLine).ToString();
        }

        public int CompareTo(object obj)
        {
            Vector v = obj as Vector;

            if (this.GetNorm() > v.GetNorm()) return 1;
            else if (this.GetNorm() < v.GetNorm()) return -1;
            else return 0;

        }

        public IEnumerator GetEnumerator()
        {
            return basic.GetEnumerator();
        }

        public object Clone()
        {
            Vector v = this.MemberwiseClone() as Vector;
            v.basic = this.basic.Clone() as int[];
            return v;
        }

        public static bool operator ==(Vector l, Vector r)
        {
            return l.Equals(r);
        }
        public static bool operator !=(Vector l, Vector r)
        {
            return !l.Equals(r);
        }
        public static bool operator >(Vector l, Vector r)
        {
            return l.CompareTo(r) > 0;
        }
        public static bool operator <(Vector l, Vector r)
        {
            return l.CompareTo(r) < 0;
        }
        public static bool operator >=(Vector l, Vector r)
        {
            return !(l < r);
        }
        public static bool operator <=(Vector l, Vector r)
        {
            return !(l > r);
        }

        public enum VectorCompareType { norm, size, sum };
        public class VectorComparer : IComparer
        {
            private VectorCompareType compareType;

            public VectorComparer(VectorCompareType CT)
            {
                this.compareType = CT;
            }

            public int Compare(object x, object y)
            {
                Vector X = x as Vector, Y = y as Vector;
                switch (compareType)
                {
                    case VectorCompareType.norm: return X.GetNorm().CompareTo(Y.GetNorm());
                    case VectorCompareType.size: return X.Size.CompareTo(Y.Size);
                    case VectorCompareType.sum: return X.GetSum().CompareTo(Y.GetSum());
                    default: throw new ArgumentException("You cannot compare in this way");
                }
            }
        }
        public static VectorComparer GetComparer(VectorCompareType CT)
        {
            return new VectorComparer(CT);
        }
    }
}