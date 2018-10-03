namespace SystemOfLinearEquations
{
    public class SOLE
    {
        // FIELDS
        Matrix A;
        Vector B;
        // CONSTRUCTORS
        public SOLE(Matrix A, Vector B)
        {
            if (A.Size != B.Size)
            {
                throw new System.ArgumentException("Matrix A and vector B should has the same size");
            }
            this.A = A;
            this.B = B;
        }
        // METHODS
        private double CalcCramerX(uint i, double deltaMain)
        {
            return A.ChangeColByVector(B, i).Determinant() / deltaMain;
        }
        private double CalcGaussX(uint i, double deltaMain)
        {
            return A.ChangeColByVector(B, i).DeterminantGauss() / deltaMain;
        }
        public Vector Run()
        {
            double deltaMain = A.Determinant();
            Vector res = new Vector(B.Size);

            for (uint i = 0; i < B.Size; ++i)
            {
                res[i] = CalcCramerX(i, deltaMain);
            }

            return res;
        }
        public Vector Run(int threadAmount)
        {
            double deltaMain = A.Determinant();
            Vector res = new Vector(B.Size);

            System.Threading.Thread[] threads = new System.Threading.Thread[threadAmount];

            int rowAmountForEachThread = A.Size / threadAmount;
            int lastFrom = A.Size - rowAmountForEachThread - 1;
            int lastTo = A.Size;
            threads[threads.Length - 1] = new System.Threading.Thread(() =>
            {
                for (uint i = (uint)lastFrom; i < lastTo; ++i)
                {
                    res[i] = CalcCramerX(i, deltaMain);
                }
            });

            for (int t = 0; t < threads.Length - 1; ++t)
            {
                // the lamba catch all variables by reference, need local copy
                int localFromRow = t * rowAmountForEachThread;
                int localToRow = t * rowAmountForEachThread + rowAmountForEachThread;
                threads[t] = new System.Threading.Thread(() =>
                {
                    for (uint i = (uint)localFromRow; i < localToRow; ++i)
                    {
                        res[i] = CalcCramerX(i, deltaMain);
                    }
                });

                threads[t].Start();
            }
            threads[threads.Length - 1].Start();

            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i].Join();
            }

            return res;
        }
        public Vector RunGauss()
        {
            double deltaMain = A.DeterminantGauss();
            Vector res = new Vector(B.Size);

            for (uint i = 0; i < B.Size; ++i)
            {
                res[i] = CalcGaussX(i, deltaMain);
            }

            return res;
        }
        public Vector RunGauss(int threadAmount)
        {
            double deltaMain = A.DeterminantGauss();
            Vector res = new Vector(B.Size);

            System.Threading.Thread[] threads = new System.Threading.Thread[threadAmount];

            int rowAmountForEachThread = A.Size / threadAmount;
            int lastFrom = A.Size - rowAmountForEachThread - 1;
            int lastTo = A.Size;
            threads[threads.Length - 1] = new System.Threading.Thread(() =>
            {
                for (uint i = (uint)lastFrom; i < lastTo; ++i)
                {
                    res[i] = CalcGaussX(i, deltaMain);
                }
            });

            for (int t = 0; t < threads.Length - 1; ++t)
            {
                // the lamba catch all variables by reference, need local copy
                int localFromRow = t * rowAmountForEachThread;
                int localToRow = t * rowAmountForEachThread + rowAmountForEachThread;
                threads[t] = new System.Threading.Thread(() =>
                {
                    for (uint i = (uint)localFromRow; i < localToRow; ++i)
                    {
                        res[i] = CalcGaussX(i, deltaMain);
                    }
                });

                threads[t].Start();
            }
            threads[threads.Length - 1].Start();

            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i].Join();
            }

            return res;
        }
    }
}
