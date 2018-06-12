using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    static class Translator
    {
        static StringDictionary dictionary;
        static string vocabularyFileName = "vocabulary.txt";

        static Translator()
        {
            dictionary = new StringDictionary();

            foreach (string line in File.ReadAllLines(vocabularyFileName))
            {
                string[] translate = line.Split();
                dictionary.Add(translate[0], translate[1]);  
            }
        }
        static public string translate(string sentence, bool justTranslate = true)
        {
            string[] words = sentence.ToLower().Split();
            StringBuilder translate = new StringBuilder();

            foreach(string word in words)
            {
                if (dictionary.ContainsKey(word))
                {
                    translate.Append(dictionary[word] + ' ');
                }
                else if(justTranslate == false)
                {
                    Console.WriteLine("I dont know \'" + word + "\'. Want to translate Y/N?");
                    string answer = Console.ReadLine().ToUpper();

                    if(answer == "Y")
                    {
                        Console.WriteLine("What does it mean?");
                        string translated = Console.ReadLine();
                        addWord(word, translated);
                        translate.Append(translated + ' ');
                    }
                }
                else
                {
                    translate.Append(word + ' ');
                }
            }

            return translate.ToString();            
        }
        static public bool addWord(string word, string translate)
        {
            string worldLower = word.ToLower();
            if (dictionary.ContainsKey(worldLower)) return false;

            string translateLower = translate.ToLower();
            dictionary.Add(worldLower, translateLower);
            File.AppendAllText(vocabularyFileName, String.Concat(worldLower, " ", translateLower, Environment.NewLine));
            
            return true;
        }
    }
}
