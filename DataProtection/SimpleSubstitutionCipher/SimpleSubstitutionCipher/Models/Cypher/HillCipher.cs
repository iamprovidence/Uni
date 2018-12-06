using SimpleSubstitutionCipher.Models.Math;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSubstitutionCipher.Models.Cypher
{
    public class HillCipher : Interfaces.ICypher
    {
        // FIELDS
        string keyWord;
        Classes.Alphabet alphabet;
        List<char> letters;
        int size;
        Matrix matrix;
        Matrix inverseMatrix;
        // CONSTRUCTORS
        public HillCipher(Classes.Alphabet alphabet, string keyWord)
        {
            this.alphabet = alphabet;
            this.letters = Alphabet.Letters.ToList();
            this.KeyWord = keyWord;
        }
        public void CalculateMatrix()
        {
            System.GC.Collect();
            size = (int)System.Math.Sqrt(keyWord.Length);
            this.matrix = new Matrix(size, size, keyWord.Select(l => letters.BinarySearch(l)));            
            int det = System.Convert.ToInt32(matrix.Determinant());
            if (det == 0 || Algorithms.GCD(det, alphabet.Lenght) != 1) throw new System.Exception("Can not build inverse matrix");
            this.inverseMatrix = matrix.InverseByModule(alphabet.Lenght);
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
                this.alphabet = value;
                this.letters = Alphabet.Letters.ToList();
                CalculateMatrix();
            }
        }
        public string KeyWord
        {
            get
            {
                return keyWord;
            }
            set
            {
                if (!MathNet.Numerics.Euclid.IsPerfectSquare(value.Length))
                {
                    throw new System.ArgumentException("Should be perfect square");
                }
                keyWord = value;
                CalculateMatrix();
            }
        }
        // METHODS
        public string Decrypt(string text)
        {
            return F(inverseMatrix, text);
        }

        public string Encrypt(string text)
        {
            text = Classes.Alphabet.TextAdapter(text);
            // fill in string for right multiplication
            if (text.Length % size != 0) text += new string(' ', size - text.Length % size);

            return F(matrix, text);
        }
        public string F(Matrix matrix, string text)
        {
            StringBuilder sb = new StringBuilder();
            // calculate
            for (int i = 0; i < text.Length; i += size)
            {
                Vector vRes = matrix * new Vector(text.Skip(i).Take(size).Select(
                    l =>
                    {
                        int index = letters.BinarySearch(l);
                        if (index == -1)
                        {
                            throw new System.IndexOutOfRangeException("Letter is not in alphabet");
                        }
                        else
                        {
                            return index;
                        }
                    }));

                foreach (int letterIndex in vRes.Enumerator())
                {
                    sb.Append(letters[letterIndex % letters.Count]);
                }
            }
            return sb.ToString();
        }
    }
}
