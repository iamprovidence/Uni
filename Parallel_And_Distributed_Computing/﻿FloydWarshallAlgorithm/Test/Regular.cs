using Microsoft.VisualStudio.TestTools.UnitTesting;
using FloydWarshallAlgorithm;

namespace Test
{
    [TestClass]
    public class Regular
    {
        [TestMethod]
        public void Small()
        {
            Floyd floyd = new Floyd(Tester.SMALL_SIZE).Generate();
            floyd.Run();
        }
        [TestMethod]
        public void Middle()
        {
            Floyd floyd = new Floyd(Tester.MIDDLE_SIZE).Generate();
            floyd.Run();
        }
        [TestMethod]
        public void Big()
        {
            Floyd floyd = new Floyd(Tester.BIG_SIZE).Generate();
            floyd.Run();
        }
    }
}