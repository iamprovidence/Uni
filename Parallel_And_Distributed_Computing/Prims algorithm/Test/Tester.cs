using Prims_Algorithm;

namespace Test
{
    static class Tester
    {
        // CONST
        public const int SMALL_SIZE = 100;
        public const int MIDDLE_SIZE = 300;
        public const int BIG_SIZE = 500;

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
        public static void TreeWeights(System.Collections.Generic.IEnumerable<int> weight)
        {
            System.Console.WriteLine(string.Concat("Weights: ",'{', string.Join(", ", weight), '}'));
        }
        public static void TreeVertex(System.Collections.Generic.IEnumerable<int> vertexes)
        {
            System.Console.WriteLine(string.Concat("Vertexes: ", '{', string.Join(", ", vertexes), '}'));
        }
    }
}
