using FiniteElementMethod.Models.Math;
using FiniteElementMethod.Models;
using System.IO;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            double R = 0.1;
            MatrixBuilder mb = new MatrixBuilder(new CoordinateSystemConfig(0, 0.4, 0, System.Math.PI/25, 4, 1),
                new CylindricalShellConfig(e:80.1e10, v:0.3, h:0.005, r:R));
            
            double[,] gNode = mb.GaussNodes;

            double phi = new Functions().phiBasis(0, gNode[0, 0], gNode[0, 1]);
            Matrix cl = mb.BuildClMatrix(0, 1, 0);

            double[] gaussWeights = mb.GaussWeights;
            double[,] gaussNodes = mb.GaussNodes;
            double detJ = mb.GetJacobian(0, gaussNodes[0, 0], gaussNodes[0, 1]);


            // PRINT

            // SUPER GLOBAL
            Matrix[,] matrix = mb.BuildGlobalMatrix();
            Matrix left = ToMatrix(matrix);
            Matrix.Write(left, "LEFT.txt");
            
            Matrix[] vector = mb.BuildGlobalVector();
            Matrix right = ToVector(vector);
            Matrix.Write(right, "RIGHT.txt");

            GaussSole gauss = new GaussSole(aMatrix: left, bVector: right, eps: 1e-50);
            Matrix result = gauss.Run();
            Matrix.Write(result, "RESULT.txt");

            System.Console.WriteLine("done");

            System.Console.Read();
        }


        static void print(Matrix m, int round = 2, int padding = 20)
        {
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    System.Console.Write(System.Math.Round(m[i, j], round).ToString().PadRight(padding));
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }
        static void write(Matrix[,] m, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int rows = 0; rows < m.GetLength(0); ++rows)
                {
                    for (int matrixRow = 0; matrixRow < 6; ++matrixRow)
                    {
                        for (int cols = 0; cols < m.GetLength(1); ++cols)
                        {
                            for (int matrixCols = 0; matrixCols < 6; ++matrixCols)
                            {
                                writer.Write(m[rows, cols][matrixRow, matrixCols].ToString().PadRight(30));
                            }
                        }
                        writer.WriteLine();
                    }
                }
            }
        }
        static Matrix ToMatrix(Matrix[,] m)
        {
            Matrix matrix = new Matrix(m.GetLength(0) * 6, m.GetLength(1) * 6);
            for (int rows = 0; rows < m.GetLength(0); ++rows)
            {
                for (int matrixRow = 0; matrixRow < 6; ++matrixRow)
                {
                    for (int cols = 0; cols < m.GetLength(1); ++cols)
                    {
                        for (int matrixCols = 0; matrixCols < 6; ++matrixCols)
                        {
                            matrix[6 * rows + matrixRow, 6 * cols + matrixCols] = m[rows, cols][matrixRow, matrixCols];
                        }
                    }
                }
            }
            return matrix;
        }

        static void write(Matrix[] v, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int block = 0; block < v.GetLength(0); ++block)
                {
                    for (int i = 0; i < v[block].Rows; i++)
                    {
                        for (int j = 0; j < v[block].Cols; j++)
                        {
                            writer.Write(v[block][i, j].ToString().PadRight(30));
                        }
                        writer.WriteLine();
                    }
                    writer.WriteLine();
                }
            }
        }

        static Matrix ToVector(Matrix[] v)
        {
            Matrix vector = new Matrix(v.GetLength(0) * 6, 1);

            for (int rows = 0; rows < v.GetLength(0); ++rows)
            {
                for (int i = 0; i < v[rows].Rows; i++)
                {
                    for (int j = 0; j < v[rows].Cols; j++)
                    {
                        vector[rows * 6 + i, j] = v[rows][i, j];
                    }
                }
            }
            return vector;
        }
    }
}
