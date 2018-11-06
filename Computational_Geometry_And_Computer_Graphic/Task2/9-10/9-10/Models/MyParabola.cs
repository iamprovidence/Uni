namespace _9_10.Models
{
    // My way, has not been used
    // parabola throught 3 point
    public class MyParabola
    {
        // FIELDS
        double a;
        double b;
        double c;
        // CONSTRUCTORS
        public MyParabola(Point A, Point B, Point C)
        {
            // y = ax2 + bx + c

            // a = ((y3 - y1)(x2 - x1) - (y2 - y1)(x3 - x1)) / ((x3^2 - x1^2)(x2 - x1) - (x2^2 - x1^2)(x3 - x1))
            // b = (y2 - y1 - a(x2^2 - x1^2)) / (x2 - x1)
            // c = y1 - (ax1^2 + bx1)

            double aX2 = A.X * A.X;
            double bX2 = B.X * B.X;
            double cX2 = C.X * C.X;

            a = ((C.Y - A.Y) * (B.X - A.X) - (B.Y - A.Y) * (C.X - A.X)) / ((cX2 - aX2) * (B.X - A.X) - (bX2 - aX2) * (C.X - A.X));
            b = (B.Y - A.Y - a * (bX2 - aX2)) / (B.X - A.X);
            c = A.Y - (a * aX2 + b * A.X);
        }
        // METHODS
        public double GetY(double x)
        {
            return a * x * x + b * x + c;
        }
    }
}
