using System.Linq;

namespace Statistics.Models
{
    static class СontinuousToDiscrete
    {
        public static DiscreteVariable ContinuosToDiscrete(DiscreteVariable veryBigDiscrete)
        {
            int r_1 = veryBigDiscrete.r_1;
            double h = veryBigDiscrete.p / r_1;
            // calculating new statistical table
            System.Collections.Generic.SortedDictionary<double, int> newStatisticalTable =
                new System.Collections.Generic.SortedDictionary<double, int>();

            System.Collections.Generic.KeyValuePair<double, int>[] oldStatisticalTable = veryBigDiscrete.GetStatisticalTable();
            double leftBorder = oldStatisticalTable.First().Key;
            double rightBorder = leftBorder + h;

            int leftIndex = 0;
            int rightIndex = 0;

            for (int i = 0; i < r_1 - 1; ++i)// for each class, except last one
            {
                // finding left and right index of element that will be summed
                while (oldStatisticalTable[rightIndex].Key < rightBorder)
                {
                    ++rightIndex;
                }
                int sum = 0;
                for (int x = leftIndex; x < rightIndex; ++x)
                {
                    sum += oldStatisticalTable[x].Value;
                }
                // set new value
                newStatisticalTable.Add((leftBorder + rightBorder) / 2, sum);

                leftIndex = rightIndex;
                leftBorder = rightBorder;
                rightBorder = leftBorder + h;
            }
            // calculate last class
            rightBorder = oldStatisticalTable.Last().Key;
            int lastSum = 0;
            for (int x = leftIndex; x < oldStatisticalTable.Length; ++x)
            {
                lastSum += oldStatisticalTable[x].Value;
            }
            // set new value
            newStatisticalTable.Add((leftBorder + rightBorder) / 2, lastSum);

            // new discrete variable has been created 
            DiscreteVariable dv = new DiscreteVariable(newStatisticalTable);

            if (dv.Size != veryBigDiscrete.Size)
            {
                throw new System.ArgumentException("Some elements has been lost");
            }
            return dv;
        }
    }
}
