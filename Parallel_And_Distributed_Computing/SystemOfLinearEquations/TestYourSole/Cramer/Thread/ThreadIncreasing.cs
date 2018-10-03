using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemOfLinearEquations;
using static TestYourSole.Tester;


namespace TestYourSole.Thread
{
    [TestClass]
    public class ThreadIncreasing
    {
        [TestMethod]
        public void SizeSmall_ThreadMiddle()
        {
            new SOLE(new Matrix(SIZE_SMALL).Randomize(), new Vector(SIZE_SMALL).Randomize()).Run(THREAD_MIDDLE);
        }
        [TestMethod]
        public void SizeSmall_ThreadBig()
        {
            new SOLE(new Matrix(SIZE_SMALL).Randomize(), new Vector(SIZE_SMALL).Randomize()).Run(THREAD_BIG);
        }
        [TestMethod]
        public void SizeBig_ThreadMiddle()
        {
            new SOLE(new Matrix(SIZE_BIG).Randomize(), new Vector(SIZE_BIG).Randomize()).Run(THREAD_MIDDLE);
        }
    }
}
