using SimpleSubstitutionCipher.Models.Classes;

namespace SimpleSubstitutionCipher.Models.Cypher
{
    public class GammaCipher : Interfaces.ICypher
    {
        // FIELDS
        Alphabet alphabet;
        uint[] key;
        uint[] Y;
        uint[] Z;
        // CONSTRUCTORS
        public GammaCipher(Alphabet alphabet, uint[] key)
        {
            this.alphabet = alphabet;
            this.key = key;
        }
        // PROPERTIES
        public Alphabet Alphabet
        {
            get
            {
                return alphabet;
            }
            set
            {
                alphabet = value;
            }
        }
        public uint[] Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
                for (int i = 0; i < key.Length; ++i)
                {
                    key[i] %= (uint)alphabet.Lenght;
                }
            }
        }
        // METHODS
        public string Decrypt(string text)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(text.Length);

            System.Collections.Generic.List<char> letters = new System.Collections.Generic.List<char>(alphabet.Letters);

            for (int i = 0; i < text.Length; ++i)
            {
                int index = letters.BinarySearch(text[i]);
                if (index != -1)
                {
                    sb.Append(letters[(int)((index + (letters.Count - Z[i])) % letters.Count)]);
                }
                else sb.Append(text[i]);
            }
            return sb.ToString();
        }

        public string Encrypt(string text)
        {
            text = Alphabet.TextAdapter(text);
            this.Y = new uint[text.Length + 1];
            this.Z = new uint[text.Length];
            System.Array.Copy(key, Y, key.Length);
            for (int i = key.Length; i < Y.Length; ++i)
            {
                Y[i] = (Y[i - 1] + Y[i - 3]) % (uint)alphabet.Lenght;
            }
            for (int i = 0; i < Z.Length; ++i)
            {
                Z[i] = (Y[i] + Y[i + 1]) % (uint)alphabet.Lenght;
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder(text.Length);

            System.Collections.Generic.List<char> letters = new System.Collections.Generic.List<char>(alphabet.Letters);

            for (int i = 0; i < text.Length; ++i)
            {
                int index = letters.BinarySearch(text[i]);
                if (index != -1)
                {
                    sb.Append(letters[(int)((index + Z[i]) % letters.Count)]);
                }
                else sb.Append(text[i]);
            }
            return sb.ToString();
        }
    }
}
