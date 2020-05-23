namespace SimpleSubstitutionCipher.Models.Classes
{
    public class Alphabet
    {
        public static System.Func<string, string> TextAdapter;
        // FIELDS
        System.Collections.Generic.SortedSet<char> letter;
        // PROPERTIES
        public int Lenght => letter.Count;
        public char[] Letters => System.Linq.Enumerable.ToArray(letter);
        // CONSTRUCTORS
        public Alphabet(string letters)
        {
            this.letter = new System.Collections.Generic.SortedSet<char>(letters);
        }
        static Alphabet()
        {
            TextAdapter = (s) => System.Text.RegularExpressions.Regex.Replace(s.ToLower(), @"\s+", " ");
        }
        // METHODS
        public void AddLetters(string letters)
        {
            foreach (char l in letters)
            {
                this.letter.Add(l);
            }
        }
    }
}
