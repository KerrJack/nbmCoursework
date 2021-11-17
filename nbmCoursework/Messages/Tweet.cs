using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nbmCoursework.Messages
{
    class Tweet : Message
    {
        public string twitterId;

        public Tweet(string aId, char aMessageType, string aMessageText, string aTwitterId) : base(aId, aMessageType, aMessageText)
        {
            twitterId = aTwitterId;
        }
    }
}
