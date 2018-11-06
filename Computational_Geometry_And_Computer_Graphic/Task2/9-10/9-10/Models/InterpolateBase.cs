namespace _9_10.Models
{
    public class InterpolateBase
    {
        protected Matrix BuildPointVector(params Point[] points)
        {
            Matrix point = new Matrix();

            foreach (Point p in points)
            {
                point.AddBottomRow(p.X, p.Y, p.Z, p.E);
            }

            return point;
        }
        protected void ConstrainParameter(double p)
        {
            if (p > 1 || p < 0) throw new System.ArgumentException("Should be between 0 and 1");
        }
        protected Matrix BuildVectorByPower(double value, int length)
        {
            Matrix res = new Matrix(1, length);

            res[0, length - 1] = 1;
            for (int i = length - 2; i >= 0; --i)
            {
                res[0, i] = res[0, i + 1] * value;
            }

            return res;
        }
        public static Matrix CalcDerivative(System.Collections.Generic.IList<Point> points)
        {
            Matrix M = new Matrix(points.Count-2, points.Count);
            Matrix B = new Matrix();
            double[] t = new double[points.Count];

            // fill in T
            double maxDistance = Point.Distance(points[0], points[points.Count - 1]);

            for (int i = 1; i < points.Count; ++i)
            {
                t[i] = maxDistance / Point.Distance(points[0], points[i]);
            }
            // set M
            int tIndex = t.Length - 1;
            for (int i = M.Rows -1; i >= 0; --i)
            {
                M[i, i] = t[tIndex];
                M[i, i+1] = 2*(t[tIndex] + t[--tIndex]);
                M[i, i+2] = t[tIndex];
            }
            // set B
            for (int i = points.Count-1; i >= 2; --i)
            {
                Point p = 3 * t[i - 1] * t[i] *
                    (System.Math.Pow(t[i - 1], 2) * (points[i] - points[i - 1])
                    +
                    System.Math.Pow(t[i], 2) * (points[i - 1] - points[i - 2]));
                B.AddTopRow(p.X, p.Y, p.Z, p.E);
            }

            // boundary condition
            M.AddTopRow(System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Repeat(0D, M.Cols)));
            M[0, 0] = 1;
            M.AddBottomRow(System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Repeat(0D, M.Cols)));
            M[M.Rows - 1, M.Cols - 1] = 1;

            B.AddTopRow(1, 1, 1, 1);
            B.AddBottomRow(1, 1, 1, 1);

            // calc 
            return M.Inverse() * B;
        }
    }
}
