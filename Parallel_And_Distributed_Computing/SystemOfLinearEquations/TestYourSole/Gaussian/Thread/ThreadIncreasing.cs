using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemOfLinearEquations;
using static TestYourSole.Tester;


namespace TestYourSole.Gaussian.Thread
{
    [TestClass]
    public class ThreadIncreasing
    {
        [TestMethod]
        public void SizeSmall_ThreadMiddle()
        {
            new SOLE(new Matrix(SIZE_SMALL_GAUSS).Randomize(), new Vector(SIZE_SMALL_GAUSS).Randomize()).RunGauss(THREAD_MIDDLE);
        }
        [TestMethod]
        public void SizeSmall_ThreadBig()
        {
            new SOLE(new Matrix(SIZE_SMALL_GAUSS).Randomize(), new Vector(SIZE_SMALL_GAUSS).Randomize()).RunGauss(THREAD_BIG);
        }
        [TestMethod]
        public void SizeBig_ThreadMiddle()
        {
            new SOLE(new Matrix(SIZE_BIG_GAUSS).Randomize(), new Vector(SIZE_BIG_GAUSS).Randomize()).RunGauss(THREAD_MIDDLE);
        }
    }
}
