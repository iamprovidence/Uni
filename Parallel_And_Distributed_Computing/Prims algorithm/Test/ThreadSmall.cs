using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prims_Algorithm;

namespace Test
{
    [TestClass]
    public class ThreadSmall
    {
        [TestMethod]
        public void SizeSmall_ThreadSmall()
        {
            new Prims(new Graph(Tester.SMALL_SIZE).Generate()).Run(startVertex: 0, threadAmount: Tester.SMALL_THREAD);
        }
        [TestMethod]
        public void SizeMiddle_ThreadSmall()
        {
            new Prims(new Graph(Tester.MIDDLE_SIZE).Generate()).Run(startVertex: 0, threadAmount: Tester.SMALL_THREAD);
        }
        [TestMethod]
        public void SizeBig_ThreadSmall()
        {
            new Prims(new Graph(Tester.BIG_SIZE).Generate()).Run(startVertex: 0, threadAmount: Tester.SMALL_THREAD);
        }
    }
}