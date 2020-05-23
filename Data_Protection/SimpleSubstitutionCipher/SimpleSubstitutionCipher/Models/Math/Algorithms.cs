namespace SimpleSubstitutionCipher.Models.Math
{
    public static class Algorithms
    {
        public static int GCD(int n, int m)
        {
            return (int)MathNet.Numerics.Euclid.GreatestCommonDivisor(n, m);
        }
        public static int ReverseByModule(int n, int m)
        {
            long x , y;
            MathNet.Numerics.Euclid.ExtendedGreatestCommonDivisor(n, m, out x, out y);            
            return  System.Convert.ToInt32(x);
        }
    }
}
