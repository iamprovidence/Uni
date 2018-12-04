using System.Linq;
using System.Numerics;

namespace RSA_ElGamal.Model.RSA
{
    /// <summary>
    /// Receive a message
    /// <para> - </para>
    /// Send a public key { E, N }
    /// <para> - </para>
    /// Dcode message with private key { D, N }
    /// </summary>
    class Receiver
    {
        // FIELDS
        BigInteger p;
        BigInteger q;

        BigInteger n;
        BigInteger phi;

        BigInteger e;
        BigInteger d;

        Alphabet alphabet;
        Algorithms algorithms;
        System.Random random;
        // CONSTRUCTORS
        public Receiver(Alphabet alphabet)
        {
            this.alphabet = alphabet;
            this.random = new System.Random();
            this.algorithms = new Algorithms();

            CalcPQ();

            CalcPhiN();

            CalcE();
            CalcD();
        }
        public Receiver(Alphabet alphabet, BigInteger p, BigInteger q)
        {
            this.alphabet = alphabet;
            this.algorithms = new Algorithms();
            this.random = new System.Random();

            if (!algorithms.IsPrime(p)) throw new System.ArgumentException("P should be Prime");
            if (!algorithms.IsPrime(q)) throw new System.ArgumentException("Q should be Prime");

            this.p = p;
            this.q = q;

            CalcPhiN();

            CalcE();
            CalcD();
        }
        // PROPERTIES
        public BigInteger P
        {
            get
            {
                return p;
            }
            set
            {
                if (!algorithms.IsPrime(value))
                {
                    throw new System.ArgumentException("P should be prime");
                }
                p = value;
            }
        }
        public BigInteger Q
        {
            get
            {
                return q;
            }
            set
            {
                if (!algorithms.IsPrime(value))
                {
                    throw new System.ArgumentException("Q should be prime");
                }
                q = value;
            }
        }
        public BigInteger N => n;
        public BigInteger E
        {
            get
            {
                return e;
            }
            set
            {
                if (!algorithms.IsCoprime(value, phi))
                {
                    throw new System.ArgumentException("E should be coprime with Ф(n)");
                }
                e = value;
                this.CalcD();
            }
        }
        public BigInteger D => d;
        public BigInteger Phi => phi;
        // METHODS
        private void CalcE()
        {
            int rand;
            do
            {
                rand = random.Next();
            } while (!algorithms.IsCoprime(rand, phi));

            e = rand;
        }
        private void CalcD()
        {
            d = algorithms.ExtendedEuclidean(e, phi);
        }
        private void CalcPQ()
        {
            do
            {
                p = random.Next();
            }
            while (!algorithms.IsPrime(p));
            do
            {
                q = random.Next();
            }
            while (!algorithms.IsPrime(q));
        }
        private void CalcPhiN()
        {
            if (!p.IsZero && !q.IsZero) this.phi = (p - 1) * (q - 1);
            this.n = p * q;
        }


        public string Decode(string text)
        {
            BigInteger[] numbers = text.Trim().Split().Select(BigInteger.Parse).ToArray();
            System.Text.StringBuilder decodedText = new System.Text.StringBuilder(numbers.Length);

            foreach (BigInteger number in numbers)
            {
                decodedText.Append(alphabet[(int)DecodeFunction(number)]);
            }
            return decodedText.ToString();
        }
        private BigInteger DecodeFunction(BigInteger C)
        {
            return BigInteger.ModPow(C, D, N);
        }
    }
}
