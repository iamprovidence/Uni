using System.Linq;

namespace SimpleSubstitutionCipher.Models.Cypher
{
    public class AffineCipher : Interfaces.ICypher
    {
        // FIELDS
        int a;
        int b;
        int m;
        // a struction that contain letter and its coded version
        System.Collections.Generic.SortedDictionary<char, char> letterCipherTable;
        Classes.Alphabet alphabet;

        // CONSTRUCTORS
        public AffineCipher(Classes.Alphabet alphabet, int a, int b)
        {

            this.a = a;
            this.b = b;
            this.m = alphabet.Lenght;

            int gcd = Math.Algorithms.GCD(a, m);
            if (gcd != 1)
            {
                throw new System.ArgumentException(string.Format("Numbers \"A\" and \"M\" must be relatively simple\n A: {0} M: {1} GCD: {2}"
                                                                    , a, m, gcd));
            }

            this.letterCipherTable = new System.Collections.Generic.SortedDictionary<char, char>();
            this.alphabet = alphabet;
            this.CreateLetterCipherTable();
        }
        // PROPERTIES
        public Classes.Alphabet Alphabet
        {
            get
            {
                return this.alphabet;
            }
            set
            {
                this.alphabet = value;
                this.m = alphabet.Lenght;
                this.CreateLetterCipherTable();
            }
        }
        public int A
        {
            get
            {
                return a;
            }
            set
            {
                
                int gcd = Math.Algorithms.GCD(value, m);
                if (gcd != 1)
                {
                    throw new System.ArgumentException(string.Format("Numbers \"A\" and \"M\" must be relatively simple\n A: {0} M: {1} GCD: {2}"
                                                                        , value, m, gcd));
                }
                a = value;
                CreateLetterCipherTable();
            }
        }
        public int B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                CreateLetterCipherTable();
            }
        }

        // METHODS        
        private void CreateLetterCipherTable()
        {
            letterCipherTable.Clear();            

            char[] letters = alphabet.Letters;

            for (int x = 0; x < letters.Length; ++x)
            {
                int letterCypherIndex = (a * x + b) % m;

                letterCipherTable.Add(letters[x], letters[letterCypherIndex]);
            }
        }

        public string Encrypt(string text)
        {
            System.Text.StringBuilder encryptedText = new System.Text.StringBuilder(text.Length);

            foreach (char letter in Classes.Alphabet.TextAdapter(text))
            {
                try
                {
                    encryptedText.Append(letterCipherTable[letter]);
                }
                catch (System.Collections.Generic.KeyNotFoundException)
                {
                    continue;
                }
            }

            return encryptedText.ToString();
        }
        public string Decrypt(string text)
        {
            System.Text.StringBuilder decryptedText = new System.Text.StringBuilder(text.Length);

            foreach (char letter in text)
            {          
                decryptedText.Append(letterCipherTable.First(x => x.Value == letter).Key);
            }

            return decryptedText.ToString();
        }
    }
}
