using MathFunc = System.Func<double, double>;

namespace FunctionInterpolation
{
    class InterpolationMethods
    {
        // FIELDS
        private readonly double a;
        private readonly double b;
        private readonly int n;
        private readonly double h;
        private double[] X;
        private double[] Y;
        private double[][] deltaY;// order, y index
        private MathFunc f;
        // CONSTRUCTORS
        public InterpolationMethods(double a, double b, int N, MathFunc F)
        {
            this.a = a;
            this.b = b;
            this.n = N;
            this.h = (b - a) / N;
            this.f = F;
            this.SetsNodes();
            this.CalcFiniteDifference();
        }
        private InterpolationMethods SetsNodes()
        {
            this.X = new double[n];
            this.Y = new double[n];
            for (int i = 0; i < n; ++i)
            {
                X[i] = a + i * h;
                Y[i] = f(X[i]);
            }
            return this;
        }
        private InterpolationMethods CalcFiniteDifference()
        {
            // for one Method is better to calculate
            // each row separately, not the matrix at once
            this.deltaY = new double[n][];

            // first deltas is just Y
            deltaY[0] = (double[])Y.Clone();

            // calc next delta, start from 1
            for (int i = 1; i < n; ++i)
            {
                // next orders is one less than previous
                deltaY[i] = new double[n - i]; 
                for (int j = 0; j < n - i; ++j)
                {
                    // next order depends on previous
                    deltaY[i][j] = deltaY[i - 1][j + 1] - deltaY[i - 1][j];
                }
            }
            return this;
        }
        // PROPERTIES
        public MathFunc F
        {
            get
            {
                return f;
            }
            set
            {
                f = value;
                SetsNodes();
                CalcFiniteDifference();
            }
        }
        public double A => a;
        public double B => b;
        public double H => h;
        public int N => n;
        // METHODS
        public (double y, int n) NewtonForward(double x, double eps, System.Collections.Generic.ICollection<string> finiteDifferenceOrder = null)
        {
            double result = Y[0];
            double reach = double.PositiveInfinity;

            double t = (x - X[0]) / h;
            double accumulateT = 1;
            double nFact = 1;// also could be in array

            int i = 1;
            while (i < n && System.Math.Abs(reach - result) > eps)
            {
                accumulateT *= t - i + 1;
                nFact *= i;

                reach = result;
                result += accumulateT / nFact * deltaY[i][0];

                finiteDifferenceOrder?.Add($"Δ{i}y{0}");

                ++i;
            }

            return (y: result, n: i);
        }
        public (double y, int n) GaussForward(double x, double eps, System.Collections.Generic.ICollection<string> finiteDifferenceOrder = null)
        {
            int c = N / 2 - 1;

            double result = Y[c];
            double reach = double.PositiveInfinity;
            double t = (x - X[c]) / h;
            double accumulateT = 1;
            double nFact = 1;// also could be in array

            int i = 1;
            while (i < n && System.Math.Abs(reach - result) > eps)
            {
                int num = i / 2;
                if (i % 2 == 0)
                {
                    num = -num;
                    c--;
                }

                accumulateT *= t + num;
                nFact *= i;

                reach = result;
                result += accumulateT / nFact * deltaY[i][c];

                finiteDifferenceOrder?.Add($"Δ{i}y{c}");

                ++i;
            }

            return (y: result, n: i);
        }
    }
}
