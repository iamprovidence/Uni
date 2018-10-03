using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemOfLinearEquations;
using static TestYourSole.Tester;

namespace TestYourSole.Regular
{
    [TestClass]
    public class Regular
    {
        [TestMethod]
        public void SizeSmall()
        {
            new SOLE(new Matrix(SIZE_SMALL).Randomize(), new Vector(SIZE_SMALL).Randomize()).Run();
        }
        [TestMethod]
        public void SizeMiddle()
        {
            new SOLE(new Matrix(SIZE_MIDDLE).Randomize(), new Vector(SIZE_MIDDLE).Randomize()).Run();
        }
        [TestMethod]
        public void SizeBig()
        {
            new SOLE(new Matrix(SIZE_BIG).Randomize(), new Vector(SIZE_BIG).Randomize()).Run();
        }
    }
}
