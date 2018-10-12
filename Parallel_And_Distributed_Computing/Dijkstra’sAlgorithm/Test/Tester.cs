using Dijkstras_Algorithm;

namespace Test
{
    static class Tester
    {
        // CONST
        public const int SMALL_SIZE = 1000;
        public const int MIDDLE_SIZE = 3000;
        public const int BIG_SIZE = 5000;

        public const int SMALL_THREAD = 2;
        public const int MIDDLE_THREAD = 4;
        public const int BIG_THREAD = 7;
        
        // METHODS
        public static void ShowGraph(Graph graph)
        {
            // EDGES

            System.Console.Write('\t');
            for (int i = 0; i < graph.Size; i++)
            {
                System.Console.Write(i);
                System.Console.Write('\t');
            }
            System.Console.WriteLine();
            System.Console.Write('\t');
            for (int i = 0; i < graph.Size; i++)
            {
                System.Console.Write('—');
                System.Console.Write('\t');
            }
            System.Console.WriteLine();
            // GRAPH
            for (int i = 0; i < graph.Size; i++)
            {
                System.Console.Write(string.Concat(i, " | \t"));
                for (int j = 0; j < graph.Size; j++)
                {
                    System.Console.Write(graph[i, j]);
                    System.Console.Write('\t');
                }
                System.Console.WriteLine();
            }

        }
        public static void ShowPath(System.Collections.Generic.IEnumerable<int> path)
        {
            System.Console.WriteLine(string.Concat('{', string.Join(", ", path), '}'));
        }
        public static void ShortestPath(int from, int to, int distance)
        {
            System.Console.WriteLine(string.Format("Shortest way from {0} to {1} is {2}", from, to, distance));
        }
    }
}
