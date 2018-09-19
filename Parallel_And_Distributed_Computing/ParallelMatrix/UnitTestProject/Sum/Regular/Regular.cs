using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelMatrix_CS;

namespace UnitTestProject
{
    [TestClass]
    public class RegularTest
    {
        [TestMethod]
        public void CS_Adding_SizeSmall()
        {
            const int SIZE = Tester.SIZE_SMALL;

            Matrix m1 = new Matrix(SIZE).Randomize();
            Matrix m2 = new Matrix(SIZE).Randomize();

            Matrix res = m1 + m2;

            Tester.MatrixSumEqual(m1, m2, res);
        }
        [TestMethod]
        public void CS_Adding_SizeMiddle()
        {
            const int SIZE = Tester.SIZE_MIDDLE;

            Matrix m1 = new Matrix(SIZE).Randomize();
            Matrix m2 = new Matrix(SIZE).Randomize();

            Matrix res = m1 + m2;

            Tester.MatrixSumEqual(m1, m2, res);
        }
        [TestMethod]
        public void CS_Adding_SizeBig()
        {
            const int SIZE = Tester.SIZE_BIG;

            Matrix m1 = new Matrix(SIZE).Randomize();
            Matrix m2 = new Matrix(SIZE).Randomize();

            Matrix res = m1 + m2;

            Tester.MatrixSumEqual(m1, m2, res);
        }
    }
}
