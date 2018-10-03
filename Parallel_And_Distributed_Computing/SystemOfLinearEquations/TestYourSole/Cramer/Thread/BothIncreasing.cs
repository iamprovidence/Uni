using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemOfLinearEquations;
using static TestYourSole.Tester;


namespace TestYourSole.Thread
{
    [TestClass]
    public class BothIncreasing
    {
        [TestMethod]
        public void SizeMiddle_ThreadBig()
        {
            new SOLE(new Matrix(SIZE_MIDDLE).Randomize(), new Vector(SIZE_MIDDLE).Randomize()).Run(THREAD_BIG);
        }
        [TestMethod]
        public void SizeMiddle_ThreadMiddle()
        {
            new SOLE(new Matrix(SIZE_MIDDLE).Randomize(), new Vector(SIZE_MIDDLE).Randomize()).Run(THREAD_MIDDLE);
        }
        [TestMethod]
        public void SizeBig_ThreadBig()
        {
            new SOLE(new Matrix(SIZE_BIG).Randomize(), new Vector(SIZE_BIG).Randomize()).Run(THREAD_BIG);
        }
    }
}
