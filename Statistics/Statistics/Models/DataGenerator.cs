using static System.Math;

namespace Statistics.Models
{
    static class DataGenerator
    {
        public static void WriteGaussianToFileData(double mu, double sigma, uint size, string fileName)
        {
            System.Random rand = new System.Random();
            
            int[] data = new int[size];
            double u1, u2, rand_std_normal;
            for (int i = 0; i < size; ++i)
            {
                u1 = rand.NextDouble();
                u2 = rand.NextDouble();

                rand_std_normal = Sqrt(-2.0 * Log(u1)) * Sin(2.0 * PI * u2);                

                data[i] = System.Convert.ToInt32(mu + sigma * rand_std_normal);
            }

            System.IO.File.WriteAllText(fileName, string.Join(";", data));
        }
        public static void WriteTriangleToFileData(double a, double b, double c, uint size, string fileName)
        {
            System.Random rand = new System.Random();

            int[] data = new int[size];
            double u;
            for (int i = 0; i < size; ++i)
            {
                u = rand.NextDouble();

                data[i] = System.Convert.ToInt32(
                    u < (c - a) / (b - a)
                            ? a + Sqrt(u * (b - a) * (c - a))
                            : b - Sqrt((1 - u) * (b - a) * (b - c)));                
            }

            System.IO.File.WriteAllText(fileName, string.Join(";", data));
        }
        public static void WriteToFileData(int a, int b, uint size, string fileName)
        {
            int[] data = new int[size];
            System.Random rand = new System.Random();

            for (int i = 0; i < size; ++i)
            {
                data[i] = rand.Next(a, b);
            }

            System.IO.File.WriteAllText(fileName, string.Join(";", data));
        }
        public static void WriteToFileData(double[] variationSeries, string fileName)
        {
            System.IO.File.WriteAllText(fileName, string.Join(";", variationSeries));
        }
        public static void WriteToFileDataTable(int a, int b, uint maxFrequency, string fileName)
        {
            const int ROWS = 2;
            int size = b - a;

            int[][] dataTable = new int[ROWS][];
            System.Random rand = new System.Random();

            for (int k = 0; k < ROWS; ++k)
            {
                dataTable[k] = new int[size];                
            }

            for (int i = 0; i < size; ++i)
            {
                // x
                dataTable[0][i] = a++;
                // n
                dataTable[1][i] = rand.Next(1, (int)maxFrequency);
            }

            System.IO.File.WriteAllText(fileName, string.Concat(
                                                    string.Join(";", dataTable[0]),
                                                    System.Environment.NewLine,
                                                    string.Join(";", dataTable[1])));
        }
        public static void WriteToFileDataTable(System.Collections.Generic.KeyValuePair<double, int>[] statisticalTable, string fileName)
        {
            System.IO.File.WriteAllText(fileName, string.Concat(
                                                    string.Join(";", System.Linq.Enumerable.Select(statisticalTable, x => x.Key)),
                                                    System.Environment.NewLine,
                                                    string.Join(";", System.Linq.Enumerable.Select(statisticalTable, x => x.Value))));
        }
    }
}