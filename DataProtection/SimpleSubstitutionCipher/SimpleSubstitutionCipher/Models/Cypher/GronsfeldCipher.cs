namespace SimpleSubstitutionCipher.Models.Cypher
{
    public class GronsfeldCipher : Interfaces.ICypher
    {
        // FIELDS
        Classes.Alphabet alphabet;
        uint[] key;
        // CONSTRUCTORS
        public GronsfeldCipher(Classes.Alphabet alphabet, uint[] key)
        {
            this.alphabet = alphabet;
            this.key = key;
        }
        // PROPERTIES
        public Classes.Alphabet Alphabet
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
                return this.key;
            }
            set
            {
                this.key = value;
                for (int i = 0; i < key.Length; ++i)
                {
                    key[i] %= 10;
                }
            }
        }
        // METHODS
        public string Decrypt(string text)
        {
            return F(text, -1);
        }

        public string Encrypt(string text)
        {
            return F(Classes.Alphabet.TextAdapter(text), 1);
        }
        private string F(string text, int shiftSide)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(text.Length);

            System.Collections.Generic.List<char> letters = new System.Collections.Generic.List<char>(alphabet.Letters);

            int k = 0;
            foreach (char l in text)
            {
                int index = letters.BinarySearch(l);
                if (index == -1)
                {
                    sb.Append(l);
                }
                else
                {
                    int offset = (index + (int)key[k] * shiftSide) % letters.Count;
                    if (offset < 0) offset += letters.Count;
                    sb.Append(letters[offset]);
                }
                ++k;
                k %= key.Length;
            }

            return sb.ToString();
        }
    }
}
