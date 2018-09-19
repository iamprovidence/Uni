using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelMatrix_CS;

namespace UnitTestProject
{
    [TestClass]
    public class BothIncreasing
    {
        [TestMethod]
        public void CS_Adding_SizeMiddle_ThreadBig()
        {
            const int SIZE = Tester.SIZE_MIDDLE;
            const int THREAD_AMOUNT = Tester.THREAD_BIG;

            Matrix m1 = new Matrix(SIZE, THREAD_AMOUNT).Randomize();
            Matrix m2 = new Matrix(SIZE, THREAD_AMOUNT).Randomize();

            Matrix res = m1 + m2;

            Tester.MatrixSumEqual(m1, m2, res);
        }
        [TestMethod]
        public void CS_Adding_SizeMiddle_ThreadMiddle()
        {
            const int SIZE = Tester.SIZE_MIDDLE;
            const int THREAD_AMOUNT = Tester.THREAD_MIDDLE;

            Matrix m1 = new Matrix(SIZE, THREAD_AMOUNT).Randomize();
            Matrix m2 = new Matrix(SIZE, THREAD_AMOUNT).Randomize();

            Matrix res = m1 + m2;

            Tester.MatrixSumEqual(m1, m2, res);
        }
        [TestMethod]
        public void CS_Adding_SizeBig_ThreadBig()
        {
            const int SIZE = Tester.SIZE_BIG;
            const int THREAD_AMOUNT = Tester.THREAD_BIG;

            Matrix m1 = new Matrix(SIZE, THREAD_AMOUNT).Randomize();
            Matrix m2 = new Matrix(SIZE, THREAD_AMOUNT).Randomize();

            Matrix res = m1 + m2;

            Tester.MatrixSumEqual(m1, m2, res);
        }
    }
}
