using System.Collections.Generic;

namespace _9_10.Models
{
    public class Matrix: System.ICloneable
    {
        // FIELDS
        int rows;
        int cols;
        List<List<double>> matrixBase;
        // CONSTRUCTORS
        public Matrix()
        {
            this.rows = 0;
            this.cols = 0;

            matrixBase = new List<List<double>>();
        }
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;

            this.matrixBase = new List<List<double>>(rows);
            for(int i = 0; i < rows; ++i)
            {
                matrixBase.Add(new List<double>(System.Linq.Enumerable.Repeat(0d, cols)));
            }
        }
        // PROPERTIES
        public int Rows => rows;
        public int Cols => cols;
        // INDEXERS
        public double this[int i, int j]
        {
            get
            {
                return matrixBase[i][j];
            }
            set
            {
                matrixBase[i][j] = value;
            }
        }
        // METHODS
        public Matrix AddBottomRow(params double[] rowsItem)
        {
            if (cols == 0) cols = rowsItem.Length;
            else if (cols != rowsItem.Length) throw new System.ArgumentException($"Wrong column amount. Shoud be {cols}");

            matrixBase.Add(new List<double>(rowsItem));
            ++rows;
            return this;
        }
        public Matrix AddTopRow(params double[] rowsItem)
        {
            if (cols == 0) cols = rowsItem.Length;
            else if (cols != rowsItem.Length) throw new System.ArgumentException($"Wrong column amount. Shoud be {cols}");

            matrixBase.Insert(0, new List<double>(rowsItem));
            ++rows;
            return this;
        }
        public Matrix Inverse()
        {
            if (this.cols != this.rows) throw new System.ArithmeticException("Matrix should be squared");
            // dont understand this shit,
            // glad it works
            int N = this.rows;
            double temp;
            
            Matrix copy = (Matrix)this.Clone();
            Matrix inverse = new Matrix(N, N);
            for (int i = 0; i < N; ++i)
            {
                inverse[i, i] = 1;
            }

            for (int k = 0; k < N; ++k)
            {
                temp = copy[k, k];

                for (int j = 0; j < N; ++j)
                {
                    copy[k, j] /= temp;
                    inverse[k, j] /= temp;
                }

                for (int i = k + 1; i < N; ++i)
                {
                    temp = copy[i, k];

                    for (int j = 0; j < N; ++j)
                    {
                        copy[i, j] -= copy[k, j] * temp;
                        inverse[i, j] -= inverse[k, j] * temp;
                    }
                }
            }

            for (int k = N - 1; k > 0; --k)
            {
                for (int i = k - 1; i >= 0; --i)
                {
                    temp = copy[i, k];

                    for (int j = 0; j < N; ++j)
                    {
                        copy[i, j] -= copy[k, j] * temp;
                        inverse[i, j] -= inverse[k, j] * temp;
                    }
                }
            }
            
            return inverse;
        }
        public object Clone()
        {
            Matrix clone = this.MemberwiseClone() as Matrix;

            for (int i = 0; i < this.rows; ++i)
            {
                clone.matrixBase[i] = new List<double>(this.matrixBase[i]);
            }

            return this;
        }
        // OPERATORS
        public static Matrix operator*(Matrix A, Matrix B)
        {
            if (A.cols != B.rows) throw new System.ArgumentException($"{nameof(A)} cols and {nameof(B)} rows should be the same");
            // building empty
            Matrix R = new Matrix(A.rows, B.cols);

            // multiplying
            for (int i = 0; i < A.rows; ++i)
            {
                for (int j = 0; j < B.cols; ++j)
                {
                    double sum = 0;
                    for (int k = 0; k < A.cols; ++k)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    R[i, j] = sum;
                }
            }

            return R;
        }
    }
}
