using FloydWarshallAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void MainMethod()
        {
            const int SIZE = 700;
            const int THREAD_SIZE = 3;
            Floyd floyd = new Floyd(SIZE).Generate();
            floyd.Run(THREAD_SIZE);
            System.Console.WriteLine(floyd[12, 9]);
        }
    }
}