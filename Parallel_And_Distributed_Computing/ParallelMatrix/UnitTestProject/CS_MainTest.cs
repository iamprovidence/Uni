using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelMatrix_CS;

namespace UnitTestProject
{
    [TestClass]
    public class CS_MainTest
    {
        [TestMethod]
        public void CS_MAIN()
        {
            const int SIZE = 100;
            const int THREAD_AMOUNT = 2;
            const Matrix.MultiplyStyle MULTIPLY_STYLE = Matrix.MultiplyStyle.Tape;

            Matrix m1 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize();
            Matrix m2 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize();

            Matrix res = m1 + m2;

            Tester.MatrixSumEqual(m1, m2, res);

            res = m1 * m2;

            Tester.MatrixMultiplyEqual(m1, m2, res);
        }
    }
}
