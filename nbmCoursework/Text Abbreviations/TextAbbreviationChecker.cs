using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nbmCoursework
{
    class TextAbbreviationChecker
    {
        Hashtable abbreviations;

        public TextAbbreviationChecker()
        {
            abbreviations = new Hashtable();
        }

        public void readFromFile()
        {

            int counter = 0;

            foreach (string line in System.IO.File.ReadLines(@"H:\nbmCoursework\nbmCoursework\Text Abbreviations\textwords.csv"))
            {
                string[] columns = line.Split(',');
                abbreviations.Add(columns[0],columns[1]);
                counter++;
            }
        }

        public string checkForAbbreviations(string sentence)
        {
            string[] words = Regex.Split(sentence, " ");

            string newSentence = "";

            foreach (var word in words)
            {
                if (abbreviations.ContainsKey(word))
                {
                    newSentence += word + " <" + abbreviations[word] + "> ";
                }
                else
                {
                    newSentence += word + " ";
                }
            }

            return newSentence;
        }
        

    }
}
