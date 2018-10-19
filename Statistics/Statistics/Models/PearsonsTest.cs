using System.Linq;
using static System.Math;

namespace Statistics.Models
{
    class PearsonsTest
    {
        // FIELDS
        DiscreteVariable dv;
        readonly double[] p;
        readonly int[] m;
        // CONSTRUCTORS
        public PearsonsTest(DiscreteVariable dv)
        {
            this.dv = dv;

            bool needToRebuild = false;
            foreach (var item in this.dv.GetStatisticalTable())
            {
                if (item.Key <= 5)
                {
                    needToRebuild = true;
                }
            }
            if (needToRebuild)
            {
                this.dv = СontinuousToDiscrete.ContinuosToDiscrete(this.dv);
            }
            if (dv.Length < 5) throw new System.ArgumentException("N < 5");
            p = CalcNormalDistributedFunctionProbabilities();
            m = this.dv.GetStatisticalTable().Select(d => d.Value).ToArray();
        }
        // PROPERTIES
        public double XiC(double alpha) => Xi_c(dv.d_f, alpha);
        public double XiE => Xi_e(m, p);
        // METHODS
        public bool CheckH0(double alpha)
        {
            return Xi_e(m, p) > Xi_c(dv.d_f, alpha);
        }
        public bool CheckH0(double Xe, double Xc)
        {
            return Xe > Xc;
        }
        private double[] CalcNormalDistributedFunctionProbabilities()
        {
            double[] p = new double[dv.Length];
            double E = dv._x;
            double D = dv.Dx;
            double sqrtD = Sqrt(D);

            double _1_sqrtD_sqrt2pi = 1 / (sqrtD * Sqrt(2 * PI));
            double _2D = 2 * D;

            for (int i = 0; i < p.Length; ++i)
            {
                p[i] = _1_sqrtD_sqrt2pi * Pow(E, -Pow((i + 1) - E, 2) / _2D);
            }

            return p;
        }
        public double Xi_e(int[] m, double[] p)
        {
            if (m.Length != p.Length)
            {
                throw new System.ArgumentException("The length of M and P should be the same");
            }

            int n = dv.Size;
            double Xi = 0;
            for (int i = 0; i < m.Length; ++i)
            {
                double nPi = n * p[i];
                if (nPi == 0) continue;
                Xi += Pow(m[i] - nPi, 2) / nPi;
            }

            return Xi;
        }
        public double Xi_c(int d_f, double alpha)
        {
            return MathNet.Numerics.Distributions.ChiSquared.InvCDF(d_f, 1 - alpha);
        }
    }
}
