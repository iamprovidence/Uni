using FiniteElementMethod.Models.Enums;

namespace FiniteElementMethod.Models
{
    public class CoordinateSystemConfig
    {
        // FIELDS
        readonly double a, b;
        readonly double c, d;

        readonly int n, m;
        
        // CONSTRUCTORS
        public CoordinateSystemConfig(double a, double b, double c, double d, int n, int m)
        {
            if (b <= a) throw new System.ArithmeticException($"{nameof(b)} can not be less than {nameof(a)}");
            if (d <= c) throw new System.ArithmeticException($"{nameof(d)} can not be less than {nameof(c)}");

            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;

            this.n = n;
            this.m = m;
        }

        // PEOPERTIES
        public double A => a;
        public double B => b;
        public double C => c;
        public double D => d;

        public int N => n;
        public int M => m;

        public double H1 => (b - a) / n;
        public double H2 => (d - c) / m;

        public int NodesAmountPerFiniteElement => 8;

        public int FiniteElementAmount => n * m;
        /// <summary>
        /// Gets nodes amount <para/>
        /// nodes amount = (vertical nodes*2 + 1) * (horizontal finite element + 1) + (middle area vertical nodes + 1) * (horizontal finite elemets) <para/>
        /// A = (N*2 + 1) * (M+1) + (N + 1) * M <para/>
        /// </summary>
        public int NodesAmount => (N * 2 + 1) * (M + 1) + (N + 1) * M; // teacher version =  (N + 1) * (M + 1) + (N * (M + 1)) + M * (N + 1);

        public int NodesRows => M * 2 + 1;
        public int NodesColsOdd => N + 1;
        public int NodesColsEven => N * 2 + 1;

        public FiniteElementDirection FiniteElementDirection => n > m ? FiniteElementDirection.Top : FiniteElementDirection.Right;
    }
}
