using System.Numerics;

namespace RSA_ElGamal.Model.RSA
{
    /// <summary>
    /// Send a message
    /// <para> - </para>
    /// Encode message with public key { E, N }
    /// </summary>
    class Sender
    {
        // FIELDS
        Alphabet alphabet;

        BigInteger e;
        BigInteger n;

        // CONSTRUCTORS
        public Sender(Alphabet alphabet)
        {
            this.alphabet = alphabet;
        }
        public Sender(Alphabet alphabet, BigInteger E, BigInteger N)
        {
            this.alphabet = alphabet;
            this.e = E;
            this.n = N;
        }
        
        // PROPERTIES
        public BigInteger E
        {
            get
            {
                return e;
            }
            set
            {
                e = value;
            }
        }
        public BigInteger N
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
            }
        }
        // METHODS
        public string Encrypt(string text)
        {
            System.Text.StringBuilder encryptedText = new System.Text.StringBuilder(text.Length);

            foreach (char letter in text)
            {
                encryptedText.Append(EnctyptFunction(letter).ToString());
                encryptedText.Append(' ');
            }

            return encryptedText.ToString();
        }
        private BigInteger EnctyptFunction(char letter)
        {
            int index = alphabet.IndexOf(letter);
            int M = index != -1 ? index : 0;
            return BigInteger.ModPow(M, E, N);
        }        
    }
}
