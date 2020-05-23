namespace SimpleSubstitutionCipher.Models.Math
{
    public class Vector
    {
        public MathNet.Numerics.LinearAlgebra.Vector<float> InnerVector { get; set; }
        public int Size => InnerVector.Count;
        public Vector(System.Collections.Generic.IEnumerable<int> enumerable)
        {
            InnerVector = 
                MathNet.Numerics.LinearAlgebra.Vector<float>.Build.DenseOfEnumerable(
                    System.Linq.Enumerable.Select(enumerable, (i => (float)i))
                    );
        }
        public Vector()
        {
            InnerVector = null;
        }
        public System.Collections.Generic.IEnumerable<int> Enumerator()
        {
            return System.Linq.Enumerable.Select(InnerVector.Enumerate(), f => (int)f);
        }
    }
}
