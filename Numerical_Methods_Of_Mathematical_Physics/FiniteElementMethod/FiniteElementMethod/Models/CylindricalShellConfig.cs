namespace FiniteElementMethod.Models
{
    public class CylindricalShellConfig
    {
        // FIELDS
        readonly double e;// модуль Юнга, пружність
        readonly double v;// коефіцієнт Пуасона, міра деформації
        readonly double h;// товщина оболонки в метрах
        readonly double r;// радіус оболонки в метрах

        // CONSTRUCTORS
        public CylindricalShellConfig(double e, double v, double h, double r)
        {
            this.e = e;
            this.v = v;
            this.h = h;
            this.r = r;
        }

        // PROPERTIES
        public double E => e;
        public double V => v;
        public double H => h;
        public double R => r;
    }
}
