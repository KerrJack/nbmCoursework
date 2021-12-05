using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nbmCoursework.Messages
{
    class SIR : Email
    {
        public string sortCode;
        public string natureOfIncident;
        

        public SIR(string aSortCode, string aNatureOfIncident, string aId, char aMessageType, string aMessageText, string aEmailAddress, string aSubject) : base(aId, aMessageType, aMessageText, aEmailAddress, aSubject)
        {
            sortCode = aSortCode;
            natureOfIncident = aNatureOfIncident;
        }
    }
}
