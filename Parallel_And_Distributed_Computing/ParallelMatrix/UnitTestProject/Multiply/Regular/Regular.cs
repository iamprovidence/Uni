using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelMatrix_CS;

namespace UnitTestProject
{
    [TestClass]
    public class RegularMultiply
    {
        [TestMethod]
        public void CS_Multiply_SizeSmall()
        {
            const int SIZE = Tester.MULTIPLY_SIZE_SMALL;

            Matrix m1 = new Matrix(SIZE).Randomize();
            Matrix m2 = new Matrix(SIZE).Randomize();

            Matrix res = m1 * m2;

            Tester.MatrixMultiplyEqual(m1, m2, res);
        }
        [TestMethod]
        public void CS_Multiply_SizeMiddle()
        {
            const int SIZE = Tester.MULTIPLY_SIZE_MIDDLE;

            Matrix m1 = new Matrix(SIZE).Randomize();
            Matrix m2 = new Matrix(SIZE).Randomize();

            Matrix res = m1 * m2;

            Tester.MatrixMultiplyEqual(m1, m2, res);
        }
        [TestMethod]
        public void CS_Multiply_SizeBig()
        {
            const int SIZE = Tester.MULTIPLY_SIZE_BIG;

            Matrix m1 = new Matrix(SIZE).Randomize();
            Matrix m2 = new Matrix(SIZE).Randomize();

            Matrix res = m1 * m2;

            Tester.MatrixMultiplyEqual(m1, m2, res);
        }
    }
}
