using FloydWarshallAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ThreadBig
    {
        [TestMethod]
        public void SizeSmall_ThreadBig()
        {
            Floyd floyd = new Floyd(Tester.SMALL_SIZE).Generate();
            floyd.Run(Tester.BIG_THREAD);
        }
        [TestMethod]
        public void SizeMiddle_ThreadBig()
        {
            Floyd floyd = new Floyd(Tester.MIDDLE_SIZE).Generate();
            floyd.Run(Tester.BIG_THREAD);
        }
        [TestMethod]
        public void SizeBig_ThreadBig()
        {
            Floyd floyd = new Floyd(Tester.BIG_SIZE).Generate();
            floyd.Run(Tester.BIG_THREAD);
        }
    }
}