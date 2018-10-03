using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemOfLinearEquations;
using static TestYourSole.Tester;


namespace TestYourSole
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void MainTestMethod()
        {
            const int SIZE = 500;
            const int THREAD_SIZE = 3;
            new SOLE(new Matrix(SIZE).Randomize(), new Vector(SIZE).Randomize()).RunGauss(THREAD_SIZE);
        }
    }
}
