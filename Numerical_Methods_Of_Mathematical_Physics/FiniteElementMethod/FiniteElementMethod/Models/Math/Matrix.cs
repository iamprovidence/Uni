using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using FiniteElementMethod.Models.Extensions;

namespace FiniteElementMethod.Models.Math
{
    public class Matrix : Interfaces.ICloneable<Matrix>, IEnumerable<double>, IEqualityComparer<Matrix>
    {
        // FIELDS
        readonly int rows;
        readonly int cols;

        readonly double[][] data;

        // CONSTRUCTORS
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;

            this.data = new double[rows][];
            for (int i = 0; i < rows; ++i)
            {
                this.data[i] = new double[cols];
            }
        }
        public static void Read(out Matrix matrix, string filePath)
        {
            char[] separators = new char[] { ' ' };
            using (StreamReader reader = new StreamReader(filePath))
            {
                int rows = int.Parse(reader.ReadLine());
                int cols = int.Parse(reader.ReadLine());

                matrix = new Matrix(rows, cols);

                for (int i = 0; i < rows; ++i)
                {
                    matrix[i] = reader.ReadLine()
                                        .Split(separators, System.StringSplitOptions.RemoveEmptyEntries)
                                        .Select(double.Parse)
                                        .ToArray();
                }
            }
        }
        public static void Write(Matrix matrix, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(matrix.rows);
                writer.WriteLine(matrix.cols);

                for (int i = 0; i < matrix.rows; ++i)
                {
                    for (int j = 0; j < matrix.cols; ++j)
                    {
                        writer.Write(matrix[i, j].ToString().PadRight(25));
                    }
                    writer.WriteLine();
                }
            }
        }

        // PROPERTIES
        public bool IsVector => cols == 1 || rows == 1;

        // INDEXERS
        public double this[int i, int j]
        {
            get
            {
                return data[i][j];
            }
            set
            {
                data[i][j] = value;
            }
        }
        public double[] this[int i]
        {
            get
            {
                return data[i];
            }
            set
            {
                if (value.Length != cols) throw new System.ArithmeticException($"Wrong cols value. Should be {cols}, actual {value.Length}");

                data[i] = value;
            }
        }

        // PROPERTIES
        public double[][] Data => data;
        public int Rows => rows;
        public int Cols => cols;
        public Matrix Transpose
        {
            get
            {
                Matrix transpose = new Matrix(cols, rows);

                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j)
                    {
                        transpose[j, i] = this[i, j];
                    }
                }
                return transpose;
            }
        }

        // METHODS
        public override bool Equals(object obj)
        {
            return Equals(this, (Matrix)obj);
        }
        public bool Equals(Matrix x, Matrix y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (x.rows != y.rows) return false;
            if (x.cols != y.cols) return false;

            for (int i = 0; i < x.rows; ++i)
            {
                for (int j = 0; j < x.cols; ++j)
                {
                    System.Console.WriteLine(x[i, j]);
                    System.Console.WriteLine(y[i, j]);
                    if (!x[i, j].IsApproximatelyEqualTo(y[i, j], 1e-4)) return false;
                }
            }

            return true;
        }
        public override int GetHashCode()
        {
            return GetHashCode(this);
        }
        public int GetHashCode(Matrix obj)
        {
            return obj.GetHashCode();
        }

        public Matrix Clone()
        {
            Matrix clone = new Matrix(rows, cols);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    clone[i, j] = this[i, j];
                }
            }
            return clone;
        }

        public IEnumerator<double> GetEnumerator()
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    yield return data[i][j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // CAST OPERATORS
        public static implicit operator Matrix(int[] vectorArr)
        {
            Matrix vector = new Matrix(rows: vectorArr.Length, cols: 1);
            for (int i = 0; i < vectorArr.Length; ++i)
            {
                vector[i, 0] = vectorArr[i];
            }
            return vector;
        }

        // OPERATIONS
        public static Matrix operator +(Matrix leftMatrix, Matrix rightMatrix)
        {
            if (leftMatrix.rows != rightMatrix.rows) throw new System.ArgumentException("Matrices should have the same number of rows");
            if (leftMatrix.cols != rightMatrix.cols) throw new System.ArgumentException("Matrices should have the same number of cols");

            Matrix result = new Matrix(leftMatrix.rows, leftMatrix.cols);
            for (int i = 0; i < leftMatrix.rows; ++i)
            {
                for (int j = 0; j < leftMatrix.cols; ++j)
                {
                    result[i, j] = leftMatrix[i, j] + rightMatrix[i, j];
                }
            }
            return result;
        }
        public static Matrix operator*(Matrix leftMatrix, Matrix rightMatrix)
        {
            if (leftMatrix.cols != rightMatrix.rows) throw new System.ArgumentException("Left matrix cols amount should be the same as right matrix rows amount");

            Matrix result = new Matrix(leftMatrix.rows, rightMatrix.cols);
            for (int i = 0; i < leftMatrix.rows; ++i)
            {
                for (int j = 0; j < rightMatrix.cols; ++j)
                {
                    for (int k = 0; k < leftMatrix.cols; ++k)
                    {
                        result[i, j] += leftMatrix[i, k] * rightMatrix[k, j];
                    }
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix matrix, double value)
        {
            Matrix result = matrix.Clone();
            for (int i = 0; i < result.rows; ++i)
            {
                for (int j = 0; j < result.cols; ++j)
                {
                    result[i, j] *= value;
                }
            }
            return result;
        }
        public static Matrix operator /(Matrix matrix, double value)
        {
            Matrix result = matrix.Clone();
            for (int i = 0; i < result.rows; ++i)
            {
                for (int j = 0; j < result.cols; ++j)
                {
                    result[i, j] /= value;
                }
            }
            return result;
        }
    }
}
