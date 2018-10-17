using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dijkstras_Algorithm;

namespace Test
{
    [TestClass]
    public class ThreadBig
    {
        [TestMethod]
        public void SizeSmall_ThreadBig()
        {
            new Dijkstra(new Graph(Tester.SMALL_SIZE).Generate()).Run(from: 0, threadAmount: Tester.BIG_THREAD);
        }
        [TestMethod]
        public void SizeMiddle_ThreadBig()
        {
            new Dijkstra(new Graph(Tester.MIDDLE_SIZE).Generate()).Run(from: 0, threadAmount: Tester.BIG_THREAD);
        }
        [TestMethod]
        public void SizeBig_ThreadBig()
        {
            new Dijkstra(new Graph(Tester.BIG_SIZE).Generate()).Run(from: 0, threadAmount: Tester.BIG_THREAD);
        }
    }
}