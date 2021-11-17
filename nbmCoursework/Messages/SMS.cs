using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nbmCoursework.Messages
{
    class SMS : Message
    {
        public string telephoneNumber;

        public SMS(string aId, char aMessageType, string aMessageText, string aTelephoneNumber) : base(aId, aMessageType, aMessageText)
        {
            telephoneNumber = aTelephoneNumber;
        }
    }
}
