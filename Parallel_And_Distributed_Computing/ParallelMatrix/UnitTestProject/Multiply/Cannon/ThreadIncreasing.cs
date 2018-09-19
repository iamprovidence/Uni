using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelMatrix_CS;

namespace UnitTestProject
{
    [TestClass]
    public class ThreadIncreasingMultiplyCannon
    {
        Matrix.MultiplyStyle MULTIPLY_STYLE = Matrix.MultiplyStyle.Cannon;
        [TestMethod]
        public void CS_Multiply_Cannon_SizeSmall_ThreadMiddle()
        {
            const int SIZE = Tester.MULTIPLY_SIZE_SMALL;
            const int THREAD_AMOUNT = Tester.THREAD_MIDDLE;

            Matrix m1 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);
            Matrix m2 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);

            Matrix res = m1 * m2;

            Tester.MatrixMultiplyEqual(m1, m2, res);
        }
        [TestMethod]
        public void CS_Multiply_Cannon_SizeSmall_ThreadBig()
        {
            const int SIZE = Tester.MULTIPLY_SIZE_SMALL;
            const int THREAD_AMOUNT = Tester.THREAD_BIG;

            Matrix m1 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);
            Matrix m2 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);

            Matrix res = m1 * m2;

            Tester.MatrixMultiplyEqual(m1, m2, res);
        }
        [TestMethod]
        public void CS_Multiply_Cannon_SizeBig_ThreadMiddle()
        {
            const int SIZE = Tester.MULTIPLY_SIZE_BIG;
            const int THREAD_AMOUNT = Tester.THREAD_MIDDLE;

            Matrix m1 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);
            Matrix m2 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);

            Matrix res = m1 * m2;

            Tester.MatrixMultiplyEqual(m1, m2, res);
        }        
    }
}
