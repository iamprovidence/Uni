using System.Linq;
using System.Collections.Generic;

namespace SystemOfLinearEquations
{
    public class Matrix
    {
        // FIELDS
        double[][] elements;
        // PROPERTIES
        public int Size => elements.Length;

        // CONSTRUCTORS
        public Matrix(int size)
        {
            elements = new double[size][];
            for (int i = 0; i < size; ++i)
            {
                elements[i] = new double[size];
            }
        }
        public Matrix Cloning(double[][] elements)
        {
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    this.elements[i][j] = elements[i][j];
                }
            }
            return this;
        }
        public Matrix Randomize()
        {
            System.Random r = new System.Random();
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    elements[i][j] = r.Next(1, 10);
                }
            }
            return this;
        }
        // METHODS
        public double DeterminantGauss()
        {
            double det = 1;
            for (int i = 0; i < Size; ++i)
            {
                int k = i;
                for (int j = i + 1; j < Size; ++j)
                {
                    if (System.Math.Abs(elements[j][i]) > System.Math.Abs(elements[k][i]))
                    {
                        k = j;
                    }
                }
                if (System.Math.Abs(elements[k][i]) < 0)
                {
                    det = 0;
                    break;
                }
                Swap(ref elements[i], ref elements[k]);
                if (i != k)
                {
                    det = -det;
                }
                det *= elements[i][i];
                for (int j = i + 1; j < Size; ++j)
                {
                    elements[i][j] /= elements[i][i];
                }
                for (int j = 0; j < Size; ++j)
                {
                    if (j != i && System.Math.Abs(elements[j][i]) > 0)
                    {
                        for (int l = i + 1; l < Size; ++l)
                        {
                            elements[j][l] -= elements[i][l] * elements[j][i];
                        }
                    }
                }
            }
            return det;
        }
        public unsafe double Determinant()
        {
            double sum = 0;
            int* indexPermutation = stackalloc int[Size];
            int p = 0;
            for (int i = 0; i < Size; ++i)
            {
                indexPermutation[i] = i;
            }

            do
            {
                double mult = 1;
                for (int i = 0; i < Size; ++i)
                {
                    mult *= elements[i][indexPermutation[i]];
                }

                if (p % 2 == 0) sum += mult;
                else sum -= mult;
                ++p;
            } while (NextPermutation(indexPermutation, indexPermutation + Size));

            return sum;
            /*long f = Factorial(Size);
            IEnumerable<int>[] permutation = GetPermutations(Enumerable.Range(0, Size), Size).ToArray();

            double sum = 0;

            for (int p = 0; p < f; ++p)
            {
                double mult = 1;
                for (int i = 0; i < Size; ++i)
                {
                    mult *= elements[i][permutation.ElementAt(p).ElementAt(i)];
                }

                if (p % 2 == 0) sum += mult;
                else sum -= mult;
            }

            return sum;*/
        }
        public Matrix ChangeColByVector(Vector V, uint colIndex)
        {
            if (this.Size != V.Size) throw new System.ArgumentException("Matrix A and vector B should has the same size");
            if (colIndex > Size) throw new System.ArgumentException("Col index can not be graeter than size");

            Matrix res = new Matrix(Size).Cloning(this.elements);
            for (int i = 0; i < Size; ++i)
            {
                elements[i][colIndex] = V[colIndex];
            }
            return res;
        }
        // PRIVATE METHODS
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        static long Factorial(int i)
        {
            if (i <= 1) return 1;
            return i * Factorial(i - 1);
        }
        // UNSAFE METHODS
        unsafe static bool NextPermutation(int* first, int* last)
        {
            if (first == last) return false;
            int* i = last;
            if (first == --i) return false;

            while (true)
            {
                int* i1, i2;

                i1 = i;
                if (*--i < *i1)
                {
                    i2 = last;
                    while (!(*i < *--i2));
                    Swap(ref *i, ref *i2);
                    Reverse(i1, last);
                    return true;
                }
                if (i == first)
                {
                    Reverse(first, last);
                    return false;
                }
            }
        }
        unsafe static void Reverse(int* first, int* last)
        {
            while ((first != last) && (first != --last))
            {
                Swap(ref *first++, ref *last);
            }
        }
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
