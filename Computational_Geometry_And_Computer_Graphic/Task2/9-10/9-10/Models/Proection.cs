using static System.Math;

namespace _9_10.Models
{
    public class Proection
    {
        // use only this
        public Matrix Ortogonal()
        {
            return new Matrix()
                .AddBottomRow(1, 0, 0, 0)
                .AddBottomRow(0, 1, 0, 0)
                .AddBottomRow(0, 0, 0, 0)
                .AddBottomRow(0, 0, 0, 1);
        }
        public Matrix Perspective()
        {
            return new Matrix()
                .AddBottomRow(1, 0, 0, 0)
                .AddBottomRow(0, 1, 0, 0)
                .AddBottomRow(0, 0, 0, 1/5)
                .AddBottomRow(0, 0, 0, 1);
        }
        public Matrix Izometrical()
        {
            return ProectionMatrix(45, 35.26);
        }
        public Matrix Dimetrical1() => ProectionMatrix(29.52, 26.23);
        public Matrix Dimetrical2() => ProectionMatrix(29.52, -26.23);
        public Matrix Dimetrical3() => ProectionMatrix(-29.52, 26.23);
        public Matrix Dimetrical4() => ProectionMatrix(-29.52, -26.23);

        private Matrix ProectionMatrix(double phi, double teta)
        {
            double sinTete = Sin(teta);
            double cosPhi = Cos(phi);
            double sinPhi = Sin(phi);
            double cosTeta = Cos(teta);

            return new Matrix()
                .AddBottomRow(cosTeta, sinTete * sinPhi, -sinTete * cosPhi, 0)
                .AddBottomRow(0, cosPhi, sinPhi, 0)
                .AddBottomRow(sinTete, -cosTeta * sinPhi, cosTeta * cosPhi, 0)
                .AddBottomRow(0, 0, 0, 1);
        }
    }
}
