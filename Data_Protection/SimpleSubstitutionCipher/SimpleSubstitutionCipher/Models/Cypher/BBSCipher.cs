namespace SimpleSubstitutionCipher.Models.Cypher
{
    public class BBSCipher : Interfaces.ICypher
    {
        // FIELDS
        Classes.Alphabet alphabet;
        RandomGenerator.BBS bbs;
        // CONSTRUCTORS
        public BBSCipher(Classes.Alphabet alphabet, RandomGenerator.BBS bbs)
        {
            this.alphabet = alphabet;
            this.bbs = bbs;
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
        public RandomGenerator.BBS BBS
        {
            get
            {
                return bbs;
            }
            set
            {
                bbs = value;
            }
        }
        // METHODS
        public string Decrypt(string text)
        {
            byte[] byteText = StringToByte(text);
            bbs.Reset();
            for (int i = 0; i < byteText.Length; ++i)
            {
                byteText[i] ^= bbs.NextByte();
            }
            
            return ByteToString(byteText);
            //return ByteToString(Xor(StringToByte(text), bbs.GenerateByteArray(text.Length)));
        }

        public string Encrypt(string text)
        {
            string clearString = Classes.Alphabet.TextAdapter(text);

            byte[] byteText = StringToByte(clearString);
            bbs.Reset();
            for (int i = 0; i < byteText.Length; ++i)
            {
                byteText[i] ^= bbs.NextByte();
            }

            return ByteToString(byteText);
            // return ByteToString(Xor(StringToByte(clearString), bbs.GenerateByteArray(clearString.Length)));
        }
        public static byte[] Xor(byte[] message, byte[] bbs)
        {
            byte[] result = new byte[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                result[i] = (byte)(message[i] ^ bbs[i]);
            }
            return result;
        }
        private byte[] StringToByte(string text) => System.Text.Encoding.Default.GetBytes(text);
        private string ByteToString(byte[] bytes) => System.Text.Encoding.Default.GetString(bytes);
    }
}
