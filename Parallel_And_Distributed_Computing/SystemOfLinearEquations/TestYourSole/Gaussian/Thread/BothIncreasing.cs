using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemOfLinearEquations;
using static TestYourSole.Tester;


namespace TestYourSole.Gaussias.Thread
{
    [TestClass]
    public class BothIncreasing
    {
        [TestMethod]
        public void SizeMiddle_ThreadBig()
        {
            new SOLE(new Matrix(SIZE_MIDDLE_GAUSS).Randomize(), new Vector(SIZE_MIDDLE_GAUSS).Randomize()).RunGauss(THREAD_BIG);
        }
        [TestMethod]
        public void SizeMiddle_ThreadMiddle()
        {
            new SOLE(new Matrix(SIZE_MIDDLE_GAUSS).Randomize(), new Vector(SIZE_MIDDLE_GAUSS).Randomize()).RunGauss(THREAD_MIDDLE);
        }
        [TestMethod]
        public void SizeBig_ThreadBig()
        {
            new SOLE(new Matrix(SIZE_BIG_GAUSS).Randomize(), new Vector(SIZE_BIG_GAUSS).Randomize()).RunGauss(THREAD_BIG);
        }
    }
}
