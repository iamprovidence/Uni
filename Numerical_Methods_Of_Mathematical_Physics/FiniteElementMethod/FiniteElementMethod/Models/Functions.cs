using static System.Math;

namespace FiniteElementMethod.Models
{
    public class Functions
    {
        public int PhiAmount => 8;

        public double phiBasis(int nodeIndex, double xi1, double xi2)
        {
            switch (nodeIndex)
            {
                case 0: return -1.0 / 4 * (1 - xi1) * (1 - xi2) * (1 + xi1 + xi2);
                case 2: return -1.0 / 4 * (1 + xi1) * (1 - xi2) * (1 - xi1 + xi2);
                case 4: return -1.0 / 4 * (1 + xi1) * (1 + xi2) * (1 - xi1 - xi2);
                case 6: return -1.0 / 4 * (1 - xi1) * (1 + xi2) * (1 + xi1 - xi2);

                case 1: return +1.0 / 2 * (1 - Pow(xi1, 2)) * (1 - xi2);
                case 3: return +1.0 / 2 * (1 - Pow(xi2, 2)) * (1 + xi1);
                case 5: return +1.0 / 2 * (1 - Pow(xi1, 2)) * (1 + xi2);
                case 7: return +1.0 / 2 * (1 - Pow(xi2, 2)) * (1 - xi1);

                default: throw new System.InvalidOperationException("Wrong node index");
            }            
        }

    }
}
