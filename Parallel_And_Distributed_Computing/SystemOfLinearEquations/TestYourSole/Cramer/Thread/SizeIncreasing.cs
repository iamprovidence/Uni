using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemOfLinearEquations;
using static TestYourSole.Tester;


namespace TestYourSole.Thread
{
    [TestClass]
    public class SizeIncreasing
    {
        [TestMethod]
        public void SizeSmall_ThreadSmall()
        {
            new SOLE(new Matrix(SIZE_SMALL).Randomize(), new Vector(SIZE_SMALL).Randomize()).Run(THREAD_SMALL);
        }
        [TestMethod]
        public void SizeMiddle_ThreadSmall()
        {
            new SOLE(new Matrix(SIZE_MIDDLE).Randomize(), new Vector(SIZE_MIDDLE).Randomize()).Run(THREAD_SMALL);
        }
        [TestMethod]
        public void SizeBig_ThreadSmall()
        {
            new SOLE(new Matrix(SIZE_BIG).Randomize(), new Vector(SIZE_BIG).Randomize()).Run(THREAD_SMALL);
        }
    }
}
