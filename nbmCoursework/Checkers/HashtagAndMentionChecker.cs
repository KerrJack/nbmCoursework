using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nbmCoursework.Checkers
{
    class HashtagAndMentionChecker
    {
        private LinkedList<string> hashtagList;
        private LinkedList<string> mentionList;
 
        public HashtagAndMentionChecker()
        {
            hashtagList = new LinkedList<string>();
            mentionList = new LinkedList<string>();
        }

        public string checkForHashtags(string sentence)
        {
            string[] words = Regex.Split(sentence, " ");

            string newSentence = "";

            foreach (var word in words)
            {
                if (word.StartsWith("#"))
                {
                    hashtagList.AddLast(word);
                }
                else if (word.StartsWith("@"))
                {
                    mentionList.AddLast(word);
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
