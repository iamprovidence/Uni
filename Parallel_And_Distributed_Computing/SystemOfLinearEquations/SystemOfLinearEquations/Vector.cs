namespace SystemOfLinearEquations
{
    public class Vector
    {
        // FIELDS
        double[] elements;
        // PROPERTIES
        public int Size => elements.Length;
        // CONSTRUCTORS
        public Vector(int size)
        {
            this.elements = new double[size];
        }
        public Vector Randomize()
        {
            System.Random r = new System.Random();
            for (int i = 0; i < Size; ++i)
            {
                elements[i] = r.Next() % 10;
            }
            return this;
        }
        // INDEXERS
        public double this[uint i]
        {
            get
            {
                return elements[i];
            }
            set
            {
                elements[i] = value;
            }
        }
    }
}
