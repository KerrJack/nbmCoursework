using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nbmCoursework
{
    class QuarantineChecker
    {
        private LinkedList<string> quarantineList;

        public QuarantineChecker()
        {
            quarantineList = new LinkedList<string>();
        }

        public string checkForURLs(string sentence)
        {
            string[] words = Regex.Split(sentence, " ");

            string newSentence = "";

            foreach (var word in words)
            {
                if (word.StartsWith("http:\\"))
                {
                    quarantineList.AddLast(word);
                    newSentence += "<URL Quarantined> ";
                }
                else
                {
                    newSentence += word + " ";
                }
            }

            return newSentence;
        }

        public LinkedList<string> getQuarantineList()
        {
            return quarantineList;
        }
    }
}
