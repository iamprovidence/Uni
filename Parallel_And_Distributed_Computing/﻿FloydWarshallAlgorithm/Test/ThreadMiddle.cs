using FloydWarshallAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ThreadMiddle
    {
        [TestMethod]
        public void SizeSmall_ThreadMiddle()
        {
            Floyd floyd = new Floyd(Tester.SMALL_SIZE).Generate();
            floyd.Run(Tester.MIDDLE_THREAD);
        }
        [TestMethod]
        public void SizeMiddle_ThreadMiddle()
        {
            Floyd floyd = new Floyd(Tester.MIDDLE_SIZE).Generate();
            floyd.Run(Tester.MIDDLE_THREAD);
        }
        [TestMethod]
        public void SizeBig_ThreadMiddle()
        {
            Floyd floyd = new Floyd(Tester.BIG_SIZE).Generate();
            floyd.Run(Tester.MIDDLE_THREAD);
        }
    }
}