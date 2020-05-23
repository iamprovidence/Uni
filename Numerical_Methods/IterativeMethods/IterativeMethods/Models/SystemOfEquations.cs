using static System.Math;
using Func = System.Func<double, double>;
using DoubleFunc = System.Func<double, double, double>;

namespace IterativeMethods
{
    class SystemOfEquations
    {
        // INNER CLASSES
        public struct XYPair
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
        // CONSTRUCTORS
        public SystemOfEquations(double startX, double startY)
        {
            this.startX = startX;
            this.startY = startY;
            this.X = startX;
            this.Y = startY;
        }
        // FIELDS
        double startX;
        double startY;
        double X;
        double Y;
        // PROPERTIES
        public double StartX
        {
            set
            {
                this.startX = value;
            }
        }
        public double StartY
        {
            set
            {
                this.startY = value;
            }
        }
        public double EPS { get; set; }
        public DoubleFunc F { get; set; }
        public DoubleFunc G { get; set; }
        public Func Fx { get; set; }
        public Func Fdx { get; set; }
        public Func Fdy { get; set; }
        public Func Gy { get; set; }
        public Func Gdx { get; set; }
        public Func Gdy { get; set; }

        // METHODS
        public XYPair IterativeMethod(out uint iterationCounter)
        {
            iterationCounter = 0;

            X = startX;
            Y = startY;

            double tempX, tempY;

            do
            {
                tempX = X;
                tempY = Y;

                X = Fx(tempY);
                Y = Gy(tempX);

                ++iterationCounter;
            } while (Abs(tempX - X) > EPS || Abs(tempY - Y) > EPS);

            return new XYPair { X = X, Y = Y };
        }
        public XYPair NewtonMethod(out uint iterationCounter)
        {
            iterationCounter = 0;

            X = startX;
            Y = startY;

            double tempX, tempY;
            double delN;

            do
            {
                tempX = X;
                tempY = Y;
                delN = deltaN(tempX, tempY);

                X = tempX + deltaX(tempX, tempY) / delN;
                Y = tempY + deltaY(tempX, tempY) / delN;

                ++iterationCounter;
            } while (Abs(tempX - X) > EPS || Abs(tempY - Y) > EPS);

            return new XYPair { X = X, Y = Y };
        }
        // PRIVATE METHODS
        private double deltaX(double x, double y)
        {
            return -(F(x, y) * Gdy(y) - Fdy(y) * G(x, y));
        }
        private double deltaY(double x, double y)
        {
            return F(x, y) * Gdx(x) - G(x, y) * Fdx(x);
        }
        private double deltaN(double x, double y)
        {
            return Fdx(x) * Gdy(y) - Fdy(y) * Gdx(x);
        }
    }
}