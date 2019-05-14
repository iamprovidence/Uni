using static System.Math;

namespace FiniteElementMethod.Models
{
    public class Derivatives
    {
        public double DerivativeOfPhiOnXi1(int nodeIndex, double xi1, double xi2)
        {
            switch (nodeIndex)
            {
                case 0: return 1.0 / 4 * (1 - xi2) * (2 * xi1 + xi2);
                case 2: return 1.0 / 4 * (1 - xi2) * (2 * xi1 - xi2);
                case 4: return 1.0 / 4 * (1 + xi2) * (2 * xi1 + xi2);
                case 6: return 1.0 / 4 * (1 + xi2) * (2 * xi1 - xi2);

                case 1: return +xi1 * (xi2 - 1);
                case 5: return -xi1 * (1 + xi2);

                case 3: return 1.0 / 2 * (1 - Pow(xi2, 2));
                case 7: return 1.0 / 2 * (Pow(xi2, 2) - 1);

                default: throw new System.InvalidOperationException("Wrong node index");
            }
        }

        public double DerivativeOfPhiOnXi2(int nodeIndex, double xi1, double xi2)
        {
            switch (nodeIndex)
            {
                case 0: return 1.0 / 4 * (1 - xi1) * (xi1 + 2 * xi2);
                case 2: return 1.0 / 4 * (1 + xi1) * (2 * xi2 - xi1);
                case 4: return 1.0 / 4 * (1 + xi1) * (xi1 + 2 * xi2);
                case 6: return 1.0 / 4 * (1 - xi1) * (2 * xi2 - xi1);

                case 1: return 1.0 / 2 * (Pow(xi1, 2) - 1);
                case 5: return 1.0 / 2 * (1 - Pow(xi1, 2));

                case 3: return -xi2 * (1 + xi1);
                case 7: return +xi2 * (xi1 - 1);

                default: throw new System.InvalidOperationException("Wrong node index");
            }
        }
    }
}
