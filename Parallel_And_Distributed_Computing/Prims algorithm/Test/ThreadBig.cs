using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prims_Algorithm;

namespace Test
{
    [TestClass]
    public class ThreadBig
    {
        [TestMethod]
        public void SizeSmall_ThreadBig()
        {
            new Prims(new Graph(Tester.SMALL_SIZE).Generate()).Run(startVertex: 0, threadAmount: Tester.BIG_THREAD);
        }
        [TestMethod]
        public void SizeMiddle_ThreadBig()
        {
            new Prims(new Graph(Tester.MIDDLE_SIZE).Generate()).Run(startVertex: 0, threadAmount: Tester.BIG_THREAD);
        }
        [TestMethod]
        public void SizeBig_ThreadBig()
        {
            new Prims(new Graph(Tester.BIG_SIZE).Generate()).Run(startVertex: 0, threadAmount: Tester.BIG_THREAD);
        }
    }
}