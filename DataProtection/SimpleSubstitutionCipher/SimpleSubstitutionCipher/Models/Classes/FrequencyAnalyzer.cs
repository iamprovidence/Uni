using System.Collections.Generic;
using System.Linq;

namespace SimpleSubstitutionCipher.Models.Classes
{
    public class FrequencyAnalyzer
    {
        // FIELDS
        SortedDictionary<char, int> letterAmount;
        Alphabet alphabet;
        // CONSTRUCTORS
        public FrequencyAnalyzer(Alphabet alphabet)
        {
            letterAmount = new SortedDictionary<char, int>();
            this.alphabet = alphabet;
        }
        // METHODS
        public KeyValuePair<char, float>[] Analyze(string text)
        {
            ResetAnalyzer();
            text = Alphabet.TextAdapter(text);

            // count letter amount in text 
            foreach (char letter in text)
            {
                if (letterAmount.ContainsKey(letter))
                {
                    ++letterAmount[letter];
                }
            }
            // calculate frequency of each letter and fill in result array
            int index = 0;
            KeyValuePair<char, float>[] res = new KeyValuePair<char, float>[letterAmount.Count];
            foreach (KeyValuePair<char, int> la in letterAmount)
            {
                res[index++] = new KeyValuePair<char, float>(la.Key, (float)System.Math.Round((double)la.Value / text.Length, 3));
            }

            return res;
        }
        public Dictionary<char, char> SetRelationOnFrequency(KeyValuePair<char, float>[] first, KeyValuePair<char, float>[] second)
        {
            int i1 = 0, i2 = 0;
            return (from F in
                        from fR in first
                        orderby fR.Value
                        select new { fR.Key, index = i1++ }
                    join S in
                        from sR in second
                        orderby sR.Value
                        select new { sR.Key, index = i2++ }
                    on F.index equals S.index
                    select new { word = F.Key, replace = S.Key })
                     .ToDictionary(x => x.replace, x => x.word);
        }
        private void ResetAnalyzer()
        {
            letterAmount.Clear();
            foreach (char letter in alphabet.Letters)
            {
                letterAmount.Add(letter, 0);
            }
        }
    }
}
