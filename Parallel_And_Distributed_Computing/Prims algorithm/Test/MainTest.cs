using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prims_Algorithm;

namespace Test
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void MainTestMethod()
        {
            const int SIZE = 500;
            const int START_FROM = 0;
            const int THREAD_AMOUNT = 3;

            Prims prims = new Prims(new Graph(SIZE).Generate());
            prims.Run(startVertex: START_FROM, threadAmount: THREAD_AMOUNT);
        }
        [TestMethod]
        public void TestMethod()
        {
            const int SIZE = 7;
            const int THREAD_SIZE = 2;
            const int START_FROM = 0;
            // current graph from wikipedia
            Graph graph = new Graph(SIZE);
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    graph[i, j] = int.MaxValue;
                }
            }
            // A 0
            // to B
            graph[0, 1] = 7;
            graph[1, 0] = 7;
            // to D
            graph[0, 3] = 5;
            graph[3, 0] = 5;

            // B 1
            // to C
            graph[1, 2] = 8;
            graph[2, 1] = 8;
            // to D
            graph[1, 3] = 9;
            graph[3, 1] = 9;
            // to E
            graph[1, 4] = 7;
            graph[4, 1] = 7;

            // C 2
            // to E
            graph[2, 4] = 5;
            graph[4, 2] = 5;

            // D 3
            // to E
            graph[3, 4] = 15;
            graph[4, 3] = 15;
            // to F
            graph[3, 5] = 6;
            graph[5, 3] = 6;

            // E 4
            // to F
            graph[4, 5] = 8;
            graph[5, 4] = 8;
            // to G
            graph[4, 6] = 9;
            graph[6, 4] = 9;

            // F 5
            // to G
            graph[5, 6] = 11;
            graph[6, 5] = 11;

            Tester.ShowGraph(graph);

            Console.WriteLine("REGULAR");
            Prims prims = new Prims(graph);
            prims.Run(startVertex: START_FROM);
            Tester.TreeVertex(prims.Path);
            Tester.TreeWeights(prims.Weghts);

            Console.WriteLine("THREADS");
            prims.Run(startVertex: START_FROM, threadAmount: THREAD_SIZE);
            Tester.TreeVertex(prims.Path);
            Tester.TreeWeights(prims.Weghts);
        }
    }
}
