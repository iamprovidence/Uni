using System;
using System.Numerics;
using System.Threading;
using static System.Math;
using System.Collections;
using System.Collections.Generic;

namespace DiffieHellman.Models
{
    // almost completly stolen from stackoverflow
    class Algorithm
    {
        public bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int boundary = (int)Floor(Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        // Random generator (thread safe)
        private ThreadLocal<Random> sGen = new ThreadLocal<Random> (() => new Random());

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

                    if (x == 1)          return false;
                    if (x == value - 1)  break;
                }

                if (x != value - 1)  return false;
            }

            return true;
        }
        public BigInteger FindPrimitiveRoot(BigInteger p)
        {
            for (BigInteger i = 0; i < p; ++i)
            {
                try
                {
                    // check as int, light version
                    if (IsPRoot(checked((int)p), checked((int)i)))
                    {
                        return i;
                    }
                }
                catch (OverflowException)
                {
                    // check as a BigInteger, hard version
                    if (IsPRoot(p, i))
                    {
                        return i;
                    }
                }                
            }
                
            return -1;
        }

        // the number A is a primitive root of P 
        // if all n^a % p full fill row from 1 to p-1        
        public bool IsPRoot(BigInteger p, BigInteger a)
        {
            if (a == 0 || a == 1) return false;

            BigInteger last = 1;
            HashSet<BigInteger> set = new HashSet<BigInteger>();
            for (BigInteger i = 0; i < p - 1; ++i)
            {
                last = (last * a) % p;
                if (set.Contains(last))
                {
                    return false;
                }
                set.Add(last);
            }
            return true;
        }        
        public bool IsPRoot(int p, int a)
        {
            if (a == 0 || a == 1) return false;

            int last = 1;
            BitArray set = new BitArray(p);
            for (BigInteger i = 0; i < p - 1; ++i)
            {
                last = (last * a) % p;
                if (set.Get(last))
                {
                    return false;
                }
                set.Set(last, true);
            }
            return true;
        }
    }
}
