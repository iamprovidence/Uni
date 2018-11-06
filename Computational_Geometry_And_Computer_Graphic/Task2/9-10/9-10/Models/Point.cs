using static System.Math;

namespace _9_10.Models
{
    public struct Point : System.IComparable<Point>
    {
        // FIELDS
        double x;
        double y;
        double z;
        double e;
        // CONSTRUCTORS
        public Point(Matrix pointVector)
        {
            if (pointVector.Rows != 1 || pointVector.Cols != 4)
            {
                throw new System.ArgumentException("Wrong point vector");
            }

            this.x = pointVector[0, 0];
            this.y = pointVector[0, 1];
            this.z = pointVector[0, 2];
            this.e = pointVector[0, 3];
        }
        public Point(double x, double y, double z)
            : this(x, y, z, 1) { }
        public Point(double x, double y, double z, double e)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.e = e;
            this.Normalize();
        }
        // PROPERTIES
        public double X => x;
        public double Y => y;
        public double Z => z;
        public double E => e;
        // METHODS
        public static Point Parse(string text)
        {
            string[] XYZ = text.Trim().Split(' ');
            return new Point
            (
                x: double.Parse(XYZ[0]),
                y: double.Parse(XYZ[1]),
                z: double.Parse(XYZ[2])
            );
        }
        public override string ToString()
        {
            return $"{X} {Y} {Z}";
        }
        public Point Normalize()
        {
            this.x /= e;
            this.y /= e;
            this.z /= e;
            this.e /= e;

            return this;
        }
        public static double Distance(Point A, Point B)
        {
            return Sqrt(Pow(B.X - A.X, 2) + Pow(B.Y - A.Y, 2) + Pow(B.Z - A.Z, 2));
        }

        public int CompareTo(Point other)
        {
            return this.X.CompareTo(other.X);
        }
        // OPERATORS
        public static Point operator *(double A, Point B)
        {
            return new Point(x: B.X * A, y: B.Y * A, z: B.Z * A);
        }
        public static Point operator *(Point P, Matrix M)
        {
            if (M.Rows != 4) throw new System.ArgumentException("Can not multiply this matrix to point. Wrong rows amount");

            return new Point(new Matrix().AddBottomRow(P.X, P.Y, P.Z, P.E) * M);
        }
        public static Point operator +(Point A, Point B)
        {
            return new Point(A.X + B.X, A.Y + B.Y, A.Z + B.Z);
        }
        public static Point operator -(Point A, Point B)
        {
            return new Point(A.X - B.X, A.Y - B.Y, A.Z - B.Z);
        }

    }
}
