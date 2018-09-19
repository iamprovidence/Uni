using System;
using System.Linq;
using System.Threading;

namespace ParallelMatrix_CS
{
    public class Matrix
    {
        public enum MultiplyStyle
        {
            Cannon,
            Tape
        }
        // FIELDS
        int[][] arr2D;
        Random r;
        int size;
        int threadAmount;
        bool workInThread;
        MultiplyStyle multiplyStyle;

        // CONSTRUCTORS
        public Matrix(int size)
        {
            r = new Random();
            this.size = size;
            arr2D = new int[size][];
            for(int i = 0; i < size; ++i)
            {
                arr2D[i] = new int[size];
            }

            workInThread = false;
            threadAmount = 0;
        }
        public Matrix(int size, int threadAmount, MultiplyStyle multiplyStyle = MultiplyStyle.Cannon)
        {
            if (threadAmount > size) throw new ArgumentException("Thread amount could not be greater than size amount");

            r = new Random();
            this.size = size;
            arr2D = new int[size][];
            for (int i = 0; i < size; ++i)
            {
                arr2D[i] = new int[size];
            }

            workInThread = true;
            this.threadAmount = threadAmount;
            this.multiplyStyle = multiplyStyle;
        }
        public Matrix(Matrix etalon)
        {
            this.size = etalon.size;
            this.arr2D = new int[size][];
            for (int i = 0; i < size; ++i)
            {
                this.arr2D[i] = new int[size];
                for (int j = 0; j < size; ++j)
                {
                    this.arr2D[i][j] = etalon[i, j];
                }
            }

            this.workInThread = etalon.workInThread;
            this.threadAmount = etalon.threadAmount;
            this.multiplyStyle = etalon.multiplyStyle;
        }
        public Matrix Randomize(int max = 100000)
        {
            for (int i = 0; i < arr2D.Length; ++i)
            {
                for (int j = 0; j < arr2D[i].Length; ++j)
                {
                    arr2D[i][j] = r.Next() % max;
                }
            }
            return this;
        }
        // PROPERTIES
        public int Size => size;
        // INDEXERS
        public int this[int i, int j]
        {
            get
            {
                return arr2D[i][j];
            }
            set
            {
                arr2D[i][j] = value;
            }
        }
        // ADDITIONAL METHODS
        private static void RowToRow(Matrix matrixA, Matrix matrixB, Matrix resMatrix, int fromRow, int toRow, Func<int, int, int> Action)
        {
            if (matrixA.size != matrixB.size || matrixA.size != resMatrix.size) throw new ArgumentException("Matrices should be the same size.");

            for (int i = fromRow; i < toRow; ++i)
            {
                for (int j = 0; j < matrixA.size; ++j)
                {
                    resMatrix[i, j] = Action(matrixA[i, j], matrixB[i, j]);
                }
            }
        }
        private static void RowToColMultiply(Matrix matrixA, Matrix matrixB, Matrix resMatrix, int fromRow, int toRow)
        {
            if (matrixA.size != matrixB.size || matrixA.size != resMatrix.size) throw new ArgumentException("Matrices should be the same size.");

            for (int i = fromRow; i < toRow; ++i)
            {
                for (int j = 0; j < matrixA.size; ++j)
                {
                    int s = 0;
                    for (int k = 0; k < matrixA.size; ++k)
                    {
                        s += matrixA[i, k] * matrixB[k, j];
                    }
                    resMatrix[i, j] = s;
                }
            }
        }
        private static void RowToRow(Matrix matrixA, Matrix matrixB, Matrix resMatrix, int fromRow, int toRow, Func<int, int, int, int> Action)
        {
            if (matrixA.size != matrixB.size || matrixA.size != resMatrix.size) throw new ArgumentException("Matrices should be the same size.");

            for (int i = fromRow; i < toRow; ++i)
            {
                for (int j = 0; j < matrixA.size; ++j)
                {
                    resMatrix[i, j] = Action(matrixA[i, j], matrixB[i, j], resMatrix[i, j]);
                }
            }
        }
        private static void RowToRowAndColToCol(Matrix matrixA, Matrix matrixB, Matrix resMatrix, int fromRow, int toRow, int fromCol, int toCol, Func<int, int, int, int> Action)
        {
            if (matrixA.size != matrixB.size || matrixA.size != resMatrix.size) throw new ArgumentException("Matrices should be the same size.");

            for (int i = fromRow; i < toRow; ++i)
            {
                for (int j = fromCol; j < toCol; ++j)
                {
                    resMatrix[i, j] = Action(matrixA[i, j], matrixB[i, j], resMatrix[i, j]);
                }
            }
        }
        // SWITCHER METHODS
        private static void RowToRowIntelligence(Matrix matrixA, Matrix matrixB, Matrix resMatrix, int fromRow, int toRow, Func<int, int, int> Action)
        {
            if (matrixA.workInThread && matrixB.workInThread) RowToRowWorkInThread(matrixA, matrixB, resMatrix, fromRow, toRow, Action);
            else RowToRow(matrixA, matrixB, resMatrix, fromRow, toRow, Action);
        }
        private static void MultiplyIntelligence(Matrix A, Matrix B, Matrix Res)
        {
            if (A.workInThread && B.workInThread)
            {
                if (A.multiplyStyle != B.multiplyStyle) throw new ArgumentException("Matrices have different multiplyStyle");

                switch (A.multiplyStyle)
                {
                    case MultiplyStyle.Cannon: CannonMultiplyThread(A, B, Res); break;
                    case MultiplyStyle.Tape: TapeMultiplyThread(A, B, Res); break;
                }
            }
            else
            {
                SimpleMultiply(A, B, Res);
            }
        }
        // METHODS + -
        private static void RowToRowWorkInThread(Matrix matrixA, Matrix matrixB, Matrix resMatrix, int fromRow, int toRow, Func<int, int, int> Action)
        {
            if (matrixA.threadAmount != matrixB.threadAmount) throw new ArgumentException("Matrices should have same thread pool size.");
            if (!matrixA.workInThread || !matrixB.workInThread) throw new ArgumentException("Both matrices should work in thread mode.");
            if (matrixA.size % matrixA.threadAmount != 0) throw new ArgumentException("Cannot divide equaly rows by threads");

            Thread[] threads = new Thread[matrixA.threadAmount];
            int rowAmountForEachThread = matrixA.size / matrixA.threadAmount;
            /*
             * last thread has a little more rows than others
            int lastFrom = matrixA.size - rowAmountForEachThread - 1;
            int lastTo = matrixA.size;
            threads[threads.Length - 1] = new Thread(() => ToEach(matrixA, matrixB, resMatrix, lastFrom, lastTo, Action));

            for (int i = 0; i < threads.Length - 1; ++i)
            {
                // the lamba catch all variables by reference, need local copy
                int localFromRow = i * rowAmountForEachThread;
                int localToRow = i * rowAmountForEachThread + rowAmountForEachThread;

                threads[i] = new Thread(() => ToEach(matrixA, matrixB, resMatrix, localFromRow, localToRow, Action));

                threads[i].Start();
            }
            threads[threads.Length - 1].Start();
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i].Join();
            }
            */
            for (int i = 0; i < threads.Length; ++i)
            {
                // the lamba catch all variables by reference, need local copy
                int localFromRow = i * rowAmountForEachThread;
                int localToRow = i * rowAmountForEachThread + rowAmountForEachThread;

                threads[i] = new Thread(() => RowToRow(matrixA, matrixB, resMatrix, localFromRow, localToRow, Action));

                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i].Join();
            }
        }
        // *
        private static void SimpleMultiply(Matrix A, Matrix B, Matrix R)
        {
            if (A.size != B.size || A.size != R.size) throw new ArgumentException("Matrices should be the same size.");

            for (int i = 0; i < A.Size; ++i)
            {
                for (int j = 0; j < A.size; ++j)
                {
                    int s = 0;
                    for (int k = 0; k < A.size; ++k)
                    {
                        s += A[i, k] * B[k, j];
                    }
                    R[i, j] = s;
                }
            }
        }
        private static void CannonMultiplyThread(Matrix A, Matrix B, Matrix R)
        {
            if (A.size != B.size || A.size != R.size) throw new ArgumentException("Matrices should be the same size.");
            if (A.threadAmount != B.threadAmount) throw new ArgumentException("Matrices should have same thread pool size.");
            if (!A.workInThread || !B.workInThread) throw new ArgumentException("Both matrices should work in thread mode.");
            if (A.size % A.threadAmount != 0) throw new ArgumentException("Cannot divide equaly matrices rows by threads");

            int amountForEachThread = A.size / A.threadAmount;
            Thread[] threads = new Thread[A.threadAmount];

            // Initializing matrix
            ShiftRowThread(threads, amountForEachThread, A);
            ShiftColThread(threads, amountForEachThread, B);

            // Cannon algorithm
            // calc Res
            CannonLineThread(threads, A, B, R, amountForEachThread);

            for (uint k = 0; k < A.Size - 1; ++k)
            {
                // shifting
                ShiftRowThread(threads, amountForEachThread, A, 1);
                ShiftColThread(threads, amountForEachThread, B, 1);

                // calc Res
                CannonLineThread(threads, A, B, R, amountForEachThread);
            }
        }
        private static void CannonLineThread(Thread[] threads, Matrix A, Matrix B, Matrix R, int lineSize)
        {
            for (int i = 0; i < threads.Length; ++i)
            {
                // the lamba catch all variables by reference, need local copy
                int localFromRow = i * lineSize;
                int localToRow = (i + 1) * lineSize;
                threads[i] = new Thread(() => RowToRow(A, B, R, localFromRow, localToRow, (a, b, r) => r + a * b));

                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i].Join();
            }
        }
        private static void ShiftRowThread(Thread[] threads, int lineSize, Matrix M, int shift = -1)
        {
            for (int t = 0; t < threads.Length; ++t)
            {
                uint start = (uint)(t * lineSize);
                uint end = (uint)((t + 1) * lineSize);

                threads[t] = new Thread(() =>
                {
                    for (uint i = start; i < end; ++i)
                    {
                        M.ShiftRowLeft(i, shift == -1 ? i : 1u);
                    }
                });

                threads[t].Start();
            }
            for (int t = 0; t < threads.Length; ++t)
            {
                threads[t].Join();
            }
        }
        private static void ShiftColThread(Thread[] threads, int lineSize, Matrix M, int shift = -1)
        {
            for (int t = 0; t < threads.Length; ++t)
            {
                uint start = (uint)(t * lineSize);
                uint end = (uint)((t + 1) * lineSize);

                threads[t] = new Thread(() =>
                {
                    for (uint j = start; j < end; ++j)
                    {
                        M.ShiftColUp(j, shift == -1 ? j : 1u);
                    }
                });

                threads[t].Start();
            }
            for (int t = 0; t < threads.Length; ++t)
            {
                threads[t].Join();
            }
        }
        private static void TapeMultiplyThread(Matrix A, Matrix B, Matrix R)
        {
            if (A.size != B.size || A.size != R.size) throw new ArgumentException("Matrices should be the same size.");
            if (A.threadAmount != B.threadAmount) throw new ArgumentException("Matrices should have same thread pool size.");
            if (!A.workInThread || !B.workInThread) throw new ArgumentException("Both matrices should work in thread mode.");
            if (A.size % A.threadAmount != 0) throw new ArgumentException("Cannot divide equaly matrices rows by threads");

            int rowAmountForEachThread = A.size / A.threadAmount;
            Thread[] threads = new Thread[A.threadAmount];

            for (int t = 0; t < threads.Length; ++t)
            {
                // the lamba catch all variables by reference, need local copy
                int localFromRow = t * rowAmountForEachThread;
                int localToRow = t * rowAmountForEachThread + rowAmountForEachThread;
                threads[t] = new Thread(() => RowToColMultiply(A, B, R, localFromRow, localToRow));
                threads[t].Start();
            }

            for (int t = 0; t < threads.Length; ++t)
            {
                threads[t].Join();
            }
        }
        // PUBLIC 
        public void ShiftRowLeft(uint rowIndex, uint shiftAmount)
        {
            if (shiftAmount > size) throw new ArgumentException("The shift can not be greater than size");
            if (shiftAmount == size || shiftAmount == 0) return;

            int[] segment = new int[shiftAmount];
            Array.Copy(arr2D[rowIndex], segment, shiftAmount);
            // shifting
            Array.Copy(arr2D[rowIndex], shiftAmount, arr2D[rowIndex], 0, arr2D[rowIndex].Length - shiftAmount);
            Array.Copy(segment, 0, arr2D[rowIndex], arr2D[rowIndex].Length - shiftAmount, segment.Length);
        }
        public void ShiftColUp(uint colIndex, uint shiftAmount)
        {
            if (shiftAmount > size) throw new ArgumentException("The shift can not be greater than size");
            if (shiftAmount == size || shiftAmount == 0) return;

            int[] segment = new int[shiftAmount];
            for (int i = 0; i < segment.Length; ++i)
            {
                segment[i] = arr2D[i][colIndex]; 
            }

            // shifting
            for (uint i = shiftAmount; i < size; ++i)
            {
                arr2D[i - shiftAmount][colIndex] = arr2D[i][colIndex];
            }
            
            for (uint i = 0; i < segment.Length; ++i)
            {
                arr2D[size - shiftAmount + i][colIndex] = segment[i];
            }
        }
        public Matrix Clone()
        {
            return new Matrix(this);
        }
        // OPERATORS
        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix res = new Matrix(A.size);
            RowToRowIntelligence(matrixA: A, matrixB: B, resMatrix: res, fromRow: 0, toRow: A.size, Action: (lItem, rItem) => lItem + rItem);
            return res;
        }
        public static Matrix operator -(Matrix A, Matrix B)
        {
            Matrix res = new Matrix(A.size);
            RowToRowIntelligence(matrixA: A, matrixB: B, resMatrix: res, fromRow: 0, toRow: A.size, Action: (lItem, rItem) => lItem - rItem);
            return res;
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix res = new Matrix(A.size);
            MultiplyIntelligence(A.Clone(), B.Clone(), res);
            return res;
        }

    }
}
