using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace nbmCoursework.Messages
{
    class NBMManager
    {
        TextAbbreviationChecker textAbbreviationChecker;
        QuarantineChecker quarantineChecker;

        public NBMManager()
        {
            quarantineChecker = new QuarantineChecker();
            textAbbreviationChecker = new TextAbbreviationChecker();
            textAbbreviationChecker.readFromFile();
        }

        public string processMessage(string header, string body)
        {
      
            if (header.StartsWith("S"))
            {
                Console.WriteLine("blah");
                // string array set up to be used for count
                string[] lines = Regex.Split(body, "\r\n");

                // setting up count for loop to count through the sms message by character
                string telephoneNumber = lines[0];
                string smsMessage = lines[1];


                int smsCharacterCount = 0;

                for (int i = 0; i < smsMessage.Length; i++)
                {
                    smsCharacterCount++;
                }

                // if loop used to count the max characters for a sms message body
                // if the message is greater than 140 characters long then message box will appear to the user
                if (smsCharacterCount > 140)
                {
                    return "Message can only be 140 characters long";
                }

                string messageTextWithAbbreviations = textAbbreviationChecker.checkForAbbreviations(smsMessage);

                SMS newSMS = new SMS(header, header[0], messageTextWithAbbreviations, telephoneNumber);

                return "SUCCESS";
            }
            else if (header.StartsWith("E"))
            {
                // if the message header begins with the letter E then a new email object will be created
                
                string[] lines = Regex.Split(body, "\r\n");

                string emailMessage = lines[2];

                int emailCharacterCount = 0;

                for (int i = 0; i < emailMessage.Length; i++)
                {
                    emailCharacterCount++;
                }

                if (emailCharacterCount > 1028)
                {
                    return "Message can only be 1028 characters long";
                }

                string emailMessageQuarantined = quarantineChecker.checkForURLs(emailMessage);

                Email newEmail = new Email(header, header[0], emailMessageQuarantined, lines[0], lines[1]);

                return "SUCCESS";
                
            }
            else if (header.StartsWith("T"))
            {
                string[] lines = Regex.Split(body, "\r\n");

                string tweetMessage = lines[1];

                int tweetCharacterCount = 0;

                for (int i = 0; i < tweetMessage.Length; i++)
                {
                    tweetCharacterCount++;
                }

                if (tweetCharacterCount > 140)
                {
                    return "Message can only be 140 characters long";
                }

                Tweet newTweet = new Tweet(header, header[0], lines[1], lines[0]);

                return "SUCCESS";
            }
            else return "Header must begin with S, E or T";
        }

    }
}
