using static System.Math;

namespace _9_10.Models
{
    public class ParabolicInterpolation : InterpolateBase
    {
        // FIELDS
        Matrix A;
        Matrix P;
        double alpha;
        double beta;
        // CONSTRUCTORS
        public ParabolicInterpolation(Point P1, Point P2, Point P3, Point P4)
        {
            InitializeAlphaBeta(P1, P2, P3, P4);
            BuildMatrixA();
            P = BuildPointVector(P1, P2, P3, P4);
        }
        private void InitializeAlphaBeta(Point P1, Point P2, Point P3, Point P4)
        {
            // distance between points for alpha and beta
            double dp21 = Point.Distance(P1, P2);
            double dp32 = Point.Distance(P3, P2);
            double dp43 = Point.Distance(P4, P3);

            // alpha and beta
            alpha = dp21 / (dp32 + dp21);
            beta = dp32 / (dp43 + dp32);
        }
        private void BuildMatrixA()
        {
            // value for matrix
            double _1_alpha = 1 - alpha;
            double _1_alpha_2 = Pow(_1_alpha, 2);
            double alpha_beta = alpha * beta;
            double _1_beta = 1 - beta;
            double beta_2 = Pow(beta, 2);

            // A matrix
            A = new Matrix(4, 4);
            // first row
            A[0, 0] = -_1_alpha_2 / alpha;
            A[0, 1] = (_1_alpha + alpha_beta) / alpha;
            A[0, 2] = (- _1_alpha - alpha_beta)/_1_beta;
            A[0, 3] = beta_2 / _1_beta;
            // second row
            A[1, 0] = (2* _1_alpha_2) / alpha;
            A[1, 1] = (-2 * _1_alpha - alpha_beta) / alpha;
            A[1, 2] = (2 * _1_alpha - beta * (1 - 2 * alpha)) / _1_beta;
            A[1, 3] = (-beta_2) / _1_beta;
            // third row
            A[2, 0] = -_1_alpha_2 / alpha;
            A[2, 1] = (1 - 2 * alpha) / alpha;
            A[2, 2] = alpha;
            A[2, 3] = 0;
            // fourth row
            A[3, 0] = 0;
            A[3, 1] = 1;
            A[3, 2] = 0;
            A[3, 3] = 0;
        }
        
        // METHODS
        public Point CalcPolynomial(double t)
        {
            ConstrainParameter(t);            
            return new Point(BuildVectorByPower(t, 4) * A * P);
        }
    }
}
