using static System.Math;
using Func = System.Func<double, double>;

namespace IterativeMethods
{
    class Equation
    {
        // FIELDS
        double xCur;
        // CONSTRUCTORS
        public Equation(double a, double b)
        {
            this.A = a;
            this.B = b;
        }
        // PROPERTIES       
        public double A { get; set; }
        public double B { get; set; }
        public double EPS { get; set; }
        public Func Function { get; set; }
        public Func Derivetive { get; set; }
        public Func DoubleDerivetive { get; set; }
        private Func NewtonFunc => (x) => x - Function(x) / Derivetive(x);// x - f(x)/f'(x)
        private System.Func<double, double, double> ChordFunc => (x1, x2) => x1 - Function(x1) * (x1 - x2) / (Function(x1) - Function(x2));// x1 - f(x1) * (x1 - x2)/f(x)-f(x2)

        // METHODS
        public double ChordMethod(out uint iterationCounter)
        {
            iterationCounter = 0;
            double x = (A + B) / 2, x0, x1;
            if (Function(A) * DoubleDerivetive(x) > 0) { x0 = A; x1 = x; }
            else if (Function(B) * DoubleDerivetive(x) > 0) { x0 = B; x1 = x; }
            else throw new System.ArithmeticException("what are thooose (ChordMethod)");

            do
            {
                xCur = ChordFunc(x1, x0);
                x0 = x1;
                x1 = xCur;

                ++iterationCounter;
            } while (Abs(Function(xCur)) > EPS);

            return xCur;
        }
        public double NewtonMethod(out uint iterationCounter)
        {
            double x = (A + B) / 2;
            if (Function(A) * DoubleDerivetive(x) > 0) xCur = A;
            else if (Function(B) * DoubleDerivetive(x) > 0) xCur = B;
            else throw new System.ArithmeticException("what are thooose (NewtonMethod)");

            for (iterationCounter = 0; Abs(Function(xCur)) > EPS; ++iterationCounter)
            {
                xCur = NewtonFunc(xCur);
            }

            return xCur;
        }
        public double CombinedMethod(out uint iterationCounter)
        {
            iterationCounter = 0;

            double x = (A + B) / 2;

            xCur = A;
            double xTilda = B;

            if (Function(A) * DoubleDerivetive(x) > 0)
            {
                do
                {
                    xTilda = ChordFunc(xCur, xTilda);
                    xCur = NewtonFunc(xCur);

                    ++iterationCounter;
                } while (Abs(xCur - xTilda) > EPS);
            }
            else if (Function(B) * DoubleDerivetive(x) > 0)
            {
                do
                {
                    xCur = ChordFunc(xCur, xTilda);
                    xTilda = NewtonFunc(xTilda);

                    ++iterationCounter;
                } while (Abs(xCur - xTilda) > EPS);
            }
            else throw new System.ArithmeticException("what are thooose (CombineMethod)");

            return xCur;
        }
    }
}