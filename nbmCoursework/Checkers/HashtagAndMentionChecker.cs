using System;
using System.Collections;
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
        private Dictionary<string,int> trendingList;
 
        public HashtagAndMentionChecker()
        {
            hashtagList = new LinkedList<string>();
            mentionList = new LinkedList<string>();
            trendingList = new Dictionary<string, int>();
        }

        public Dictionary<string,int> getSortedTrendingList()
        {
            trendingList.Clear();

            foreach (String hashtag in hashtagList)
            {
                if (trendingList.ContainsKey(hashtag))
                {
                    trendingList[hashtag]++;
                } else
                {
                    trendingList.Add(hashtag, 1);
                }
            }

            return trendingList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public string checkForHashtags(string sentence)
        {
            string[] words = Regex.Split(sentence, " ");

            string newSentence = "";

            foreach (var word in words)
            {
                if (word.StartsWith("#"))
                {
                    hashtagList.AddLast(word+"\n");
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

        public void displayMentionList()
        {
            foreach (string mention in mentionList)
            {
                Console.WriteLine(mention);
            }
        }

        public LinkedList<string> getMentionList()
        {
            return mentionList;
        }

        public LinkedList<string> getHashtagList()
        {
            return hashtagList;
        }


        

    }

}
