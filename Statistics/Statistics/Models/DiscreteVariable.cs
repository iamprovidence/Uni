using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Math;

namespace Statistics.Models
{
    public class DiscreteVariable
    {
        // FIELDS
        SortedDictionary<double, int> statisticalTable;
        int size;
        // PROPERTIES
        public int Size => size;// volume
        public int Length => statisticalTable.Count; // table length
        public double Dx => Mh(2);
        public double Me
        {
            get
            {
                int k = (int)Floor((float)size / 2);
                double[] series = this.GetVariationSeries();

                if (size % 2 == 0)// even
                {
                    return (series[k] + series[k - 1]) / 2;
                }
                else // odd
                {
                    return series[k];
                }
            }
        }
        public double[] Mo
        {
            get
            {
                int max = statisticalTable.Values.Max();
                return statisticalTable.Where(elem => elem.Value == max).Select(elem => elem.Key).ToArray();
            }
        }
        public double _x => statisticalTable.Sum(elem => elem.Key * elem.Value) / size;
        public double Dev
        {
            get
            {
                double xAvg = this._x;

                return statisticalTable.Sum(el => el.Value * Pow(el.Key - xAvg, 2));
            }
        }
        public int d_f => size >= 2 ? size - 1 : 1;
        public double s2 => Dev / d_f;
        public double s => Sqrt(s2);
        public double p => statisticalTable.Last().Key - statisticalTable.First().Key;
        public double V => s / _x;

        public double As => Mh(3) / Pow(Mh(2), 1.5);
        public double Ek => Mh(4) / Pow(Mh(2), 2) - 3;
        public int r_1
        {
            get
            {
                int r = 1;
                int count = 2;
                while (count < size)
                {
                    count *= 2;
                    ++r;
                }
                return r;
            }
        }
        // CONSTRUCTORS
        DiscreteVariable()
        {
            statisticalTable = new SortedDictionary<double, int>();
            size = 0;
        }
        public DiscreteVariable(SortedDictionary<double, int> statisticalTable)
        {
            this.statisticalTable = statisticalTable;
            size = statisticalTable.Sum(x => x.Value);
        }
        public static DiscreteVariable ReadStatisticalTable(string fileName)
        {
            return OperateTableData( File.ReadAllLines(fileName));            
        }
        public static DiscreteVariable OperateTableData(string[] stringData)
        {
            double[] xArr = stringData[0].Split(';').Select(double.Parse).ToArray();
            int[] nArr = stringData[1].Split(';').Select(int.Parse).ToArray();

            if (xArr.Length != nArr.Length) throw new System.IO.InvalidDataException("The length of both rows should be the same");

            DiscreteVariable dv = new DiscreteVariable();
            for (int i = 0; i < xArr.Length; ++i)
            {
                dv.statisticalTable.Add(xArr[i], nArr[i]);
                dv.size += nArr[i];
            }
            if (dv.size < 2)
            {
                throw new System.ArgumentException("Too small.");
            }
            return dv;
        }
        public static DiscreteVariable ReadData(string fileName)
        {
            return OperateData(File.ReadAllText(fileName));        
        }
        public static DiscreteVariable OperateData(string stringData)
        {
            double[] xArr = stringData.Split(';').Select(double.Parse).ToArray();

            DiscreteVariable dv = new DiscreteVariable();
            foreach (double x in xArr)
            {
                if (dv.statisticalTable.ContainsKey(x))
                {
                    ++dv.statisticalTable[x];
                }
                else
                {
                    dv.statisticalTable.Add(x, 1);
                }
                ++dv.size;
            }
            if (dv.size < 2)
            {
                throw new System.ArgumentException("Too small.");
            }
            return dv;
        }

        // METHODS
        public double[] GetVariationSeries()
        {
            List<double> series = new List<double>(size);
            foreach (KeyValuePair<double, int> element in statisticalTable)
            {
                series.AddRange(Enumerable.Repeat(element: element.Key, count: element.Value));
            }
            return series.ToArray();
        }
        public KeyValuePair<double, int>[] GetStatisticalTable()
        {
            return statisticalTable.ToArray();
        }
        public KeyValuePair<double, double>[] GetCumulativeDistributionFunction()
        {
            List<KeyValuePair<double, double>> func = new List<KeyValuePair<double, double>>(size + 2);
            double k = 0;
            func.Add(new KeyValuePair<double, double>(statisticalTable.First().Key - 1, 0));
            foreach (KeyValuePair<double, int> element in statisticalTable)
            {
                k += element.Value;
                func.Add(new KeyValuePair<double, double>(element.Key, Round( k / size, 2)));
            }
            func.Add(new KeyValuePair<double, double>(statisticalTable.Last().Key + 1, 1));

            return func.ToArray();
        }
        public double Mh(int h, double a)
        {
            if (h < 1 || h > size) throw new System.ArgumentException("Out range");

            return GetVariationSeries().Sum(el => Pow(el - a, h)) / size;
        }
        public double mh(int h)
        {
            return Mh(h, 0);
        }
        public double Mh(int h)
        {
            if (h == 1) return 0;

            return Mh(h, _x);
        }
        // interquantility latitudes
        public double x(int i)
        {
            if (i < 0 || i > size) throw new System.IndexOutOfRangeException("current index is not allowed");

            return i * 100 / size;
        }
        public double q(float i)
        {
            if (i % (100 / size) == 0)
            {
                float xI = (i * size) / 100;
                if (xI % 1 == 0)
                {
                    // -1 cuz indices start with 0 not with 1
                    return GetVariationSeries()[(int)xI - 1];
                }
                else
                {
                    throw new System.IndexOutOfRangeException("something is wrong with your index");
                }
            }
            else
            {
                throw new System.ArgumentException("must be a multiple");
            }
        }
        public double Q(int i) => q(IL.Q(i));
        public double D(int i) => q(IL.D(i));
        public double O(int i) => q(IL.O(i));
        public double C(int i) => q(IL.C(i));
        public double M(int i) => q(IL.M(i));

        private static class IL
        {
            public static int Q(int i) => new int[] { 25, 50, 75 }[i - 1];
            public static int D(int i) => Enumerable.Range(1, 10).Select(x => x * 10).ElementAt(i - 1);
            public static float O(int i) => Enumerable.Range(125, 1000).Where(x => x % 125 == 0).Select(x => (float)x / 10).ElementAt(i - 1);
            public static int C(int i) => Enumerable.Range(1, 100).ElementAt(i - 1);
            public static float M(int i) => Enumerable.Range(1, 1000).Select(x => (float)x / 10).ElementAt(i - 1);
        }

    }
}