using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dijkstras_Algorithm;

namespace Test
{
    [TestClass]
    public class Regular
    {
        [TestMethod]
        public void Small()
        {
            new Dijkstra(new Graph(Tester.SMALL_SIZE).Generate()).Run(from: 0);
        }
        [TestMethod]
        public void Middle()
        {
            new Dijkstra(new Graph(Tester.MIDDLE_SIZE).Generate()).Run(from: 0);
        }
        [TestMethod]
        public void Big()
        {
            new Dijkstra(new Graph(Tester.BIG_SIZE).Generate()).Run(from: 0);
        }
    }
}