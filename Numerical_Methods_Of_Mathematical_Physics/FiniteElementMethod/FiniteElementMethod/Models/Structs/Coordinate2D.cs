namespace FiniteElementMethod.Models.Structs
{
    public struct Coordinate2D
    {
        // FIELDS
        double x;
        double y;

        // CONSTRUCTORS
        public Coordinate2D(double[] coordinate)
        {
            if (coordinate.Length != 2) throw new System.ArgumentException("There should be only two coordinate");

            x = coordinate[0];
            y = coordinate[1];
        }

        // PROPERTIES
        public double X => x;
        public double Y => y;

        // OPERATORS
        public static implicit operator Coordinate2D(double[] coordinate)
        {
            return new Coordinate2D(coordinate);
        }
    }
}
