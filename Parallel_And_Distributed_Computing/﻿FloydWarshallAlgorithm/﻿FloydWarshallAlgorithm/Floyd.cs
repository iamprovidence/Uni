namespace FloydWarshallAlgorithm
{
    public class Floyd
    {
        // CONST
        const int NO_EDGE_VALUE = 100000;
        // FIELDS
        uint[,] graph;
        int size;
        // CONSTRUCTORS
        public Floyd(int size)
        {
            this.graph = new uint[size, size];
            this.size = size;
        }
        public Floyd Generate(float randomRate = 0.25F)
        {
            System.Random rand = new System.Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j) graph[i, j] = 0;
                    else if (rand.NextDouble() < randomRate) graph[i, j] = NO_EDGE_VALUE;
                    else graph[i, j] = (uint)rand.Next(1, 10);
                }
            }
            return this;
        }
        // INDIXERS
        public uint this[int i, int j]
        {
            get
            {
                return graph[i, j];
            }
        }

        // METHODS
        private void ForEachRow(int k, int fromRow, int toRow)
        {
            for (int i = fromRow; i < toRow; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    graph[i, j] = System.Math.Min(graph[i, j], graph[i, k] + graph[k, j]);
                }
            }
        }
        public void Run()
        {
            for (int k = 0; k < size; ++k)
            {
                ForEachRow(k, 0, size);
            }
        }
        public void Run(int threadAmount)
        {
            System.Threading.Thread[] threads = null;

            int rowAmountForEachThread = size / threadAmount;
            int lastFrom = size - rowAmountForEachThread - 1;
            int lastTo = size;

            for (int k = 0; k < size; k++)
            {
                threads = new System.Threading.Thread[threadAmount];

                threads[threads.Length - 1] = new System.Threading.Thread(() =>
                {
                    ForEachRow(k, lastFrom, lastTo);
                });
                for (int t = 0; t < threads.Length - 1; ++t)
                {
                    // the lamba catch all variables by reference, need local copy
                    int localFromRow = t * rowAmountForEachThread;
                    int localToRow = t * rowAmountForEachThread + rowAmountForEachThread;
                    threads[t] = new System.Threading.Thread(() =>
                    {
                        ForEachRow(k, localFromRow, localToRow);
                    });

                    threads[t].Start();
                }
                threads[threads.Length - 1].Start();
                for (int t = 0; t < threads.Length; ++t)
                {
                    threads[t].Join();
                }
            }
        }
    }
}