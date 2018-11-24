using System.Numerics;

namespace DiffieHellman.Models
{
    class Side
    {
        // FIELDS
        BigInteger p;
        BigInteger a;
        uint numPower;
        // CONSTRUCTORS
        public Side(BigInteger p, BigInteger a)
        {
            this.p = p;
            this.a = a;
            this.numPower = 0;
        }
        // PROPERTIES
        public uint NumPower
        {
            get
            {
                return numPower;
            }
            set
            {
                numPower = value;
            }
        }
        
        // METHODS
        public BigInteger CalculateValueForOtherSide()
        {
            return BigInteger.ModPow(a, numPower, p);
        }
        public BigInteger CalculateKey(BigInteger valueFromOtherSide)
        {
            return BigInteger.ModPow(valueFromOtherSide, numPower, p);
        }
    }
}
