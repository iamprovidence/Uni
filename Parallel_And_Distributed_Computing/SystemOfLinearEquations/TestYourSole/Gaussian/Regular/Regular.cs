using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemOfLinearEquations;
using static TestYourSole.Tester;

namespace TestYourSole.Gaussian.Regular
{
    [TestClass]
    public class Regular
    {
        [TestMethod]
        public void SizeSmall()
        {
            new SOLE(new Matrix(SIZE_SMALL_GAUSS).Randomize(), new Vector(SIZE_SMALL_GAUSS).Randomize()).RunGauss();
        }
        [TestMethod]
        public void SizeMiddle()
        {
            new SOLE(new Matrix(SIZE_MIDDLE_GAUSS).Randomize(), new Vector(SIZE_MIDDLE_GAUSS).Randomize()).RunGauss();
        }
        [TestMethod]
        public void SizeBig()
        {
            new SOLE(new Matrix(SIZE_BIG_GAUSS).Randomize(), new Vector(SIZE_BIG_GAUSS).Randomize()).RunGauss();
        }
    }
}
