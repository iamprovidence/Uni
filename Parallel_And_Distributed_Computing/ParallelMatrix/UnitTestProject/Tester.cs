using ParallelMatrix_CS;

namespace UnitTestProject
{
    static class Tester
    {
        public const int SIZE_SMALL = 100;
        public const int SIZE_MIDDLE = 1000;
        public const int SIZE_BIG = 8000;

        public const int MULTIPLY_SIZE_SMALL = 300;
        public const int MULTIPLY_SIZE_MIDDLE = 500;
        public const int MULTIPLY_SIZE_BIG = 1000;

        public const int THREAD_SMALL = 4;
        public const int THREAD_MIDDLE = 25;
        public const int THREAD_BIG = 100;

        public static void MatrixSumEqual(Matrix A, Matrix B, Matrix R)
        {
            for (int i = 0; i < A.Size; ++i)
            {
                for (int j = 0; j < A.Size; ++j)
                {
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(R[i, j], A[i, j] + B[i, j]);
                }
            }
        }
        public static void MatrixMultiplyEqual(Matrix A, Matrix B, Matrix R)
        {            
            for(int i = 0; i < A.Size; ++i)
            {
                for(int j = 0; j < A.Size; ++j)
                {
                    int el = 0;
                    for (int k = 0; k < A.Size; ++k)
                    {
                        el += A[i, k] * B[k, j];
                    }

                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(R[i, j], el);
                }
            }
        }
    }
}
