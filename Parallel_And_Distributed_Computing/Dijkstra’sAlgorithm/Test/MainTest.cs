using Dijkstras_Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void MainTestMethod()
        {
            const int SIZE = 1000;
            const int START_FROM = 0;
            const int DISTANCE_TO = 1;
            const int THREAD_AMOUNT = 3;
            
            Dijkstra dijkstra = new Dijkstra(new Graph(SIZE).Generate());
            dijkstra.Run(from: START_FROM, threadAmount: THREAD_AMOUNT);
            Tester.ShortestPath(START_FROM, DISTANCE_TO, dijkstra[DISTANCE_TO]);
        }
        [TestMethod]
        public void TestMethod()
        {
            const int SIZE = 6;
            const int THREAD_SIZE = 2;
            const int START_FROM = 0;
            const int DISTANCE_TO = 2;
            // current graph from wikipedia
            Graph graph = new Graph(SIZE);
            graph[0, 1] = 7;
            graph[1, 0] = 7;

            graph[0, 2] = 9;
            graph[2, 0] = 9;

            graph[0, 5] = 14;
            graph[5, 0] = 14;

            graph[1, 2] = 10;
            graph[2, 1] = 10;

            graph[1, 3] = 15;
            graph[3, 1] = 15;

            graph[2, 3] = 11;
            graph[3, 2] = 11;

            graph[3, 4] = 6;
            graph[4, 3] = 6;

            graph[4, 5] = 9;
            graph[5, 4] = 9;

            graph[2, 5] = 2;
            graph[5, 2] = 2;

            Tester.ShowGraph(graph);

            Dijkstra dijkstra = new Dijkstra(graph);
            dijkstra.Run(from: START_FROM);
            Tester.ShortestPath(START_FROM, DISTANCE_TO, dijkstra[DISTANCE_TO]);
            Tester.ShowPath(dijkstra.Path);


            dijkstra.Run(from: START_FROM, threadAmount: THREAD_SIZE);
            Tester.ShortestPath(START_FROM, DISTANCE_TO, dijkstra[DISTANCE_TO]);
            Tester.ShowPath(dijkstra.Path);
        }
    }
}
