﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nbmCoursework.Messages
{
    class Message
    {
        public string id;
        public char messageType;
        public string messageText;

        public Message(string aId, char aMessageType, string aMessageText)
        {
            id = aId;
            messageType = aMessageType;
            messageText = aMessageText;
        }
    }
}
