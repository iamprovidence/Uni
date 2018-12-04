using System;
using System.Numerics;
using System.Threading;
using static System.Math;

namespace RSA_ElGamal.Model
{
    class Algorithms
    {
        // IsPrime
        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Floor(Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        // IsPrime BigInteger MillerRabin test 
        // Random generator (thread safe)
        private ThreadLocal<Random> sGen = new ThreadLocal<Random>(() => new Random());

        // Random generator (thread safe)
        private Random Gen
        {
            get
            {
                return sGen.Value;
            }
        }
        public Boolean IsPrime(BigInteger value, int witnesses = 10)
        {
            if (value <= 1) return false;
            if (value == 2) return true;

            if (witnesses <= 0) witnesses = 10;

            BigInteger d = value - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            Byte[] bytes = new Byte[value.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    Gen.NextBytes(bytes);

                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= value - 2);

                BigInteger x = BigInteger.ModPow(a, d, value);
                if (x == 1 || x == value - 1) continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, value);

                    if (x == 1) return false;
                    if (x == value - 1) break;
                }

                if (x != value - 1) return false;
            }

            return true;
        }
        // GCD
        public int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        public BigInteger GCD(BigInteger a, BigInteger b)
        {
            return BigInteger.GreatestCommonDivisor(a, b);
        }
        // IsCoprime
        public bool IsCoprime(int a, int b)
        {
            return GCD(a, b) == 1;
        }
        public bool IsCoprime(BigInteger a, BigInteger b)
        {
            return GCD(a, b) == 1;
        }
        // Extended Euclidean algorithm
        public int ExtendedEuclidean(int a, int m)
        {
            a = a % m;
            for (int x = 1; x < m; ++x)
            {
                if ((a * x) % m == 1)
                {
                    return x;
                }
            }
                
            return 1;
        }
        
        public BigInteger ExtendedEuclidean(BigInteger a, BigInteger b)
        {
            BigInteger dividend = a % b;
            BigInteger divisor = b;

            BigInteger last_x = BigInteger.One;
            BigInteger curr_x = BigInteger.Zero;

            while (divisor.Sign > 0)
            {
                BigInteger remainder;
                
                BigInteger quotient = BigInteger.DivRem(dividend, divisor, out remainder);
                if (remainder.Sign <= 0)
                {
                    break;
                }

                BigInteger next_x = last_x - quotient * curr_x;
                last_x = curr_x;
                curr_x = next_x;

                dividend = divisor;
                divisor = remainder;
            }

            if (divisor != BigInteger.One)
            {
                throw new System.ArithmeticException("Given numbers are not coprimes");
            }
            return curr_x.Sign < 0 ? curr_x + b : curr_x;
        }
        // Hash Function
        public BigInteger HashFunction(Alphabet alpahbet, string str, BigInteger n)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                sum += alpahbet.IndexOf(str[i]);
            }
            return sum % n;
        }
        // Digital signature
        public BigInteger CalcDigitalSignature(BigInteger value, BigInteger exponent, BigInteger modulus)
        {
            return BigInteger.ModPow(value, exponent, modulus);
        }
    }
}
