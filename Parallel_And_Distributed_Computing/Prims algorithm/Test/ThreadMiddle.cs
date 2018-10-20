using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prims_Algorithm;

namespace Test
{
    [TestClass]
    public class ThreadMiddle
    {
        [TestMethod]
        public void SizeSmall_ThreadMiddle()
        {
            new Prims(new Graph(Tester.SMALL_SIZE).Generate()).Run(startVertex: 0, threadAmount: Tester.MIDDLE_THREAD);
        }
        [TestMethod]
        public void SizeMiddle_ThreadMiddle()
        {
            new Prims(new Graph(Tester.MIDDLE_SIZE).Generate()).Run(startVertex: 0, threadAmount: Tester.MIDDLE_THREAD);
        }
        [TestMethod]
        public void SizeBig_ThreadMiddle()
        {
            new Prims(new Graph(Tester.BIG_SIZE).Generate()).Run(startVertex: 0, threadAmount: Tester.MIDDLE_THREAD);
        }
    }
}