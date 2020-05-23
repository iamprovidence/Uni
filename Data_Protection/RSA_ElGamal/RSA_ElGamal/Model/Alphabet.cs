namespace RSA_ElGamal.Model
{
    class Alphabet
    {
        public static System.Func<string, string> TextAdapter;
        // FIELDS
        System.Collections.Generic.List<char> letters;
        // PROPERTIES
        public int Lenght => letters.Count;
        public char[] Letters => letters.ToArray();
        // CONSTRUCTORS
        public Alphabet(string letters)
        {
            this.letters = new System.Collections.Generic.List<char>(letters.Length);
            AddLetters(letters);
        }
        static Alphabet()
        {
            TextAdapter = (s) => System.Text.RegularExpressions.Regex.Replace(s.ToLower(), @"\s+", " ");
        }
        // INDIXERS
        public char this[int index] => letters[index];
        // METHODS
        public void AddLetters(string letters)
        {
            this.letters.AddRange(letters);
            this.letters.Sort();
        }
        public int IndexOf(char letter)
        {
            return letters.BinarySearch(letter);
        }
    }
}
