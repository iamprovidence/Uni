using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dijkstras_Algorithm;

namespace Test
{
    [TestClass]
    public class ThreadMiddle
    {
        [TestMethod]
        public void SizeSmall_ThreadMiddle()
        {
            new Dijkstra(new Graph(Tester.SMALL_SIZE).Generate()).Run(from: 0, threadAmount: Tester.MIDDLE_THREAD);
        }
        [TestMethod]
        public void SizeMiddle_ThreadMiddle()
        {
            new Dijkstra(new Graph(Tester.MIDDLE_SIZE).Generate()).Run(from: 0, threadAmount: Tester.MIDDLE_THREAD);
        }
        [TestMethod]
        public void SizeBig_ThreadMiddle()
        {
            new Dijkstra(new Graph(Tester.BIG_SIZE).Generate()).Run(from: 0, threadAmount: Tester.MIDDLE_THREAD);
        }
    }
}