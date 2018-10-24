using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prims_Algorithm;

namespace Test
{
    [TestClass]
    public class Regular
    {
        [TestMethod]
        public void Small()
        {
            new Prims(new Graph(Tester.SMALL_SIZE).Generate()).Run(0);
        }
        [TestMethod]
        public void Middle()
        {
            new Prims(new Graph(Tester.MIDDLE_SIZE).Generate()).Run(0);
        }
        [TestMethod]
        public void Big()
        {
            new Prims(new Graph(Tester.BIG_SIZE).Generate()).Run(0);
        }
    }
}