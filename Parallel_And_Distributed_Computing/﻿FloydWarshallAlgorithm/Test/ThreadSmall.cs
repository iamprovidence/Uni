using Microsoft.VisualStudio.TestTools.UnitTesting;
using FloydWarshallAlgorithm;

namespace Test
{
    [TestClass]
    public class ThreadSmall
    {
        [TestMethod]
        public void SizeSmall_ThreadSmall()
        {
            Floyd floyd = new Floyd(Tester.SMALL_SIZE).Generate();
            floyd.Run(Tester.SMALL_THREAD);
        }
        [TestMethod]
        public void SizeMiddle_ThreadSmall()
        {
            Floyd floyd = new Floyd(Tester.MIDDLE_SIZE).Generate();
            floyd.Run(Tester.SMALL_THREAD);
        }
        [TestMethod]
        public void SizeBig_ThreadSmall()
        {
            Floyd floyd = new Floyd(Tester.BIG_SIZE).Generate();
            floyd.Run(Tester.SMALL_THREAD);
        }
    }
}