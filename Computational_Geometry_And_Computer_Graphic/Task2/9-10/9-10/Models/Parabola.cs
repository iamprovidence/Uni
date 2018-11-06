namespace _9_10.Models
{
    public class Parabola : InterpolateBase
    {
        // FIELDS
        double value;
        Matrix B;
        // CONSTRUCTORS
        public Parabola(Point p1, Point p2, Point p3)
        {
            // calc value
            double dp21 = Point.Distance(p1, p2);
            value = dp21 / (Point.Distance(p3, p2) + dp21);
            B = BuildInverseMatrix() * BuildPointVector(p1, p2, p3);
        }
        private Matrix BuildInverseMatrix()
        {
            Matrix res = new Matrix(3, 3);

            double _1_V = 1 - value;
            double _1_V_1_V = 1 / (value * _1_V);

            // first row
            res[0, 0] = 1 / value;
            res[0, 1] = -_1_V_1_V;
            res[0, 2] = 1 / _1_V;
            // second row
            res[1, 0] = -(1 + value) / value;
            res[1, 1] = _1_V_1_V;
            res[1, 2] = -value / _1_V;
            // third row
            res[2, 0] = 1;
            res[2, 1] = 0;
            res[2, 2] = 0;

            return res;
        }
        // PROPERTIES
        public double Value => value;
        // METHODS
        public Point GetPoint(double s)
        {
            ConstrainParameter(s);
            return new Point (BuildVectorByPower(s, 3) * B);
        }
    }
}
