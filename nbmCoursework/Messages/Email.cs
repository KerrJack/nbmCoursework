using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nbmCoursework.Messages
{
    class Email : Message
    {
        public string emailAddress;
        public string subject;

        public Email(string aId, char aMessageType, string aMessageText, string aEmailAddress, string aSubject) : base(aId, aMessageType, aMessageText)
        {
            emailAddress = aEmailAddress;
            subject = aSubject;
        }
    }

}
