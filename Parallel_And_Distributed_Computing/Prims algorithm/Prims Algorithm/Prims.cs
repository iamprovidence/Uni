namespace Prims_Algorithm
{
    public class Prims
    {
        // FIELDS
        Graph graph;

        int[] vertexes;
        int[] weights;
        bool[] visited;

        int minEdgeValue;
        int minEdgeIndex;
        // CONSTRUCTORS
        public Prims(Graph graph)
        {
            this.graph = graph;
            this.vertexes = new int[graph.Size];
            this.weights = new int[graph.Size];
            this.visited = new bool[graph.Size];

            minEdgeValue = int.MaxValue;
            minEdgeIndex = -1;
            Reset();
        }
        public Prims Reset()
        {
            for (int i = 0; i < graph.Size; ++i)
            {
                vertexes[i] = -1;
                weights[i] = int.MaxValue;
                visited[i] = false;
            }
            ResetIdex();
            return this;
        }
        public void ResetIdex()
        {
            minEdgeValue = int.MaxValue;
            minEdgeIndex = -1;
        }
        // PROPERTIES
        public int[] Path
        {
            get
            {
                return vertexes;
            }
        }
        public int[] Weghts
        {
            get
            {
                return weights;
            }
        }
        // METHODS
        public void SearchingNextEdge(int from, int to)
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    if (visited[j] == false && graph[i,j] < minEdgeValue)
                    {
                        minEdgeValue = graph[i, j];
                        minEdgeIndex = j;
                    }
                }
            }

        }
        public void Run(int startVertex)
        {
            Reset();
            int nextVertexIndex = 1;
            weights[0] = 0;
            vertexes[0] = startVertex;
            visited[startVertex] = true;

            while (nextVertexIndex < graph.Size)
            {
                SearchingNextEdge(0, graph.Size);

                visited[minEdgeIndex] = true;
                weights[nextVertexIndex] = minEdgeValue;
                vertexes[nextVertexIndex] = minEdgeIndex;
                ++nextVertexIndex;
                ResetIdex();
            }
        }
        public void Run(int startVertex,int threadAmount)
        {
            Reset();
            // algorithm config
            int nextVertexIndex = 1;
            weights[0] = 0;
            vertexes[0] = startVertex;
            visited[startVertex] = true;

            // thread config
            System.Threading.Thread[] threads = null;

            int rowAmountForEachThread = graph.Size / threadAmount;
            int lastFrom = graph.Size - rowAmountForEachThread - 1;
            int lastTo = graph.Size;

            while (nextVertexIndex < graph.Size)
            {
                threads = new System.Threading.Thread[threadAmount];
                threads[threads.Length - 1] = new System.Threading.Thread(() =>
                {
                    SearchingNextEdge(lastFrom, lastTo);
                });
                for (int t = 0; t < threads.Length - 1; ++t)
                {
                    // the lamba catch all variables by reference, need local copy
                    int localFromRow = t * rowAmountForEachThread;
                    int localToRow = t * rowAmountForEachThread + rowAmountForEachThread;
                    threads[t] = new System.Threading.Thread(() =>
                    {
                        SearchingNextEdge(localFromRow, localToRow);
                    });

                    threads[t].Start();
                }
                threads[threads.Length - 1].Start();
                for (int t = 0; t < threads.Length; ++t)
                {
                    threads[t].Join();
                }

                visited[minEdgeIndex] = true;
                weights[nextVertexIndex] = minEdgeValue;
                vertexes[nextVertexIndex] = minEdgeIndex;
                ++nextVertexIndex;
                ResetIdex();
            }
        }
    }
}
