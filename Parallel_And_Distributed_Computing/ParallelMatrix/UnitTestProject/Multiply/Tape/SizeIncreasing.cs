using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelMatrix_CS;

namespace UnitTestProject
{
    [TestClass]
    public class SizeIncreasingMultiplyTape
    {
        Matrix.MultiplyStyle MULTIPLY_STYLE = Matrix.MultiplyStyle.Tape;
        [TestMethod]
        public void CS_Multiply_Tape_SizeSmall_ThreadSmall()
        {
            const int SIZE = Tester.MULTIPLY_SIZE_SMALL;
            const int THREAD_AMOUNT = Tester.THREAD_SMALL;

            Matrix m1 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);
            Matrix m2 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);

            Matrix res = m1 * m2;

            Tester.MatrixMultiplyEqual(m1, m2, res);
        }
        [TestMethod]
        public void CS_Multiply_Tape_SizeMiddle_ThreadSmall()
        {
            const int SIZE = Tester.MULTIPLY_SIZE_MIDDLE;
            const int THREAD_AMOUNT = Tester.THREAD_SMALL;

            Matrix m1 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);
            Matrix m2 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);

            Matrix res = m1 * m2;

            Tester.MatrixMultiplyEqual(m1, m2, res);
        }
        [TestMethod]
        public void CS_Multiply_Tape_SizeBig_ThreadSmall()
        {
            const int SIZE = Tester.MULTIPLY_SIZE_BIG;
            const int THREAD_AMOUNT = Tester.THREAD_SMALL;

            Matrix m1 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);
            Matrix m2 = new Matrix(SIZE, THREAD_AMOUNT, MULTIPLY_STYLE).Randomize(100);

            Matrix res = m1 * m2;

            Tester.MatrixMultiplyEqual(m1, m2, res);
        }
    }
}
