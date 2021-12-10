using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;

namespace nbmCoursework.Messages
{
    class NBMManager
    {
        TextAbbreviationChecker textAbbreviationChecker;

        QuarantineChecker quarantineChecker;
        nbmCoursework.Checkers.HashtagAndMentionChecker hashtagAndMentionChecker;
        private LinkedList<Message> messageList;
        private LinkedList<string> sirList;



        public NBMManager()
        {
            quarantineChecker = new QuarantineChecker();
            textAbbreviationChecker = new TextAbbreviationChecker();
            hashtagAndMentionChecker = new Checkers.HashtagAndMentionChecker();
            textAbbreviationChecker.readFromFile();
            messageList = new LinkedList<Message>();
            sirList = new LinkedList<string>();
        }

        public string processMessage(string header, string body)
        {
      
            if (header.StartsWith("S"))
            {
                
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

                messageList.AddLast(newSMS);

                return "SUCCESS";
            }
            else if (header.StartsWith("E"))
            {
                
                // splitting the email body line by line
                string[] lines = Regex.Split(body, "\r\n");

                string emailMessage = lines[2];

                string subject = lines[1];

                // subject of the email is split into words to check the date is in the correct format for SIR's
                string[] word = subject.Split(' ');
                DateTime dDate;

                int emailCharacterCount = 0;

                // count used for counting the characters in the email message
                for (int i = 0; i < emailMessage.Length; i++)
                {
                    emailCharacterCount++;
                }

                if (emailCharacterCount > 1028)
                {
                    return "Message can only be 1028 characters long";
                }

                // if the subject begins with SIR then a check will be done on the formatting of the date added
                if (subject.StartsWith("SIR"))
                {
                    if (DateTime.TryParse(word[1], out dDate))
                    {
                        // processMessageResult value will be updated to the string below and the user will have to put in a valid date
                        String.Format("{0:d/mm/yyyy}", dDate);
                        string emailMessageQuarantined = quarantineChecker.checkForURLs(emailMessage);
                        SIR newSIR = new SIR(lines[2], lines[3], header, header[0], lines[4], lines[0], lines[1]);

                        messageList.AddLast(newSIR);
                        sirList.AddLast(newSIR.sortCode + " " + newSIR.natureOfIncident);
                        return "SUCCESS";
                    }
                    else
                    {
                        // if all info is correct then a new instance of the SIR class will be created and the sortcode and nature of incident will be added to the SIR list
                        //SIR newSIR = new SIR(lines[2], lines[3], header, header[0], lines[4], lines[0], lines[1]);

                        return "You must enter the date in the formate dd/mm/yyyy";

                    }
                    
                }
                else {
                    string emailMessageQuarantined = quarantineChecker.checkForURLs(emailMessage);
                    // if it is a standard email then a new instance of the Email class will be created
                    Email newEmail = new Email(header, header[0], emailMessageQuarantined, lines[0], lines[1]);

                    messageList.AddLast(newEmail);

                    return "SUCCESS";
                }
                


                
            }
            // if header begins with with a capital T then the folowing code will be accessed
            else if (header.StartsWith("T"))
            {
                // splitting the body of the message 
                string[] lines = Regex.Split(body, "\r\n");

                string tweetMessage = lines[1];

                int tweetCharacterCount = 0;

                // loop used to count the characters in the tweet text
                for (int i = 0; i < tweetMessage.Length; i++)
                {
                    tweetCharacterCount++;
                }

                if (tweetCharacterCount > 140)
                {
                    // processMessageResult value will be updated to the string below and the user will be asked to enter a tweet that is equal to or less than 140 characters
                    return "Message can only be 140 characters long";
                }

                // Using the checkForAbbreviations method to check through the tweet and replace with new boody of text before adding the message to a list
                string messageTextWithAbbreviations = textAbbreviationChecker.checkForAbbreviations(tweetMessage);
                hashtagAndMentionChecker.checkForHashtags(tweetMessage);

                Tweet newTweet = new Tweet(header, header[0], messageTextWithAbbreviations, lines[0]);

                messageList.AddLast(newTweet);

                return "SUCCESS";
            }
            // if the header does not begin with S, E or T then they will be asked to try again
            else return "Header must begin with S, E or T";
        }

        // method used to display the hashtag list to the user on the main window
        public void displayMentionList()
        {
            hashtagAndMentionChecker.displayMentionList();
        }

        public LinkedList<string> getMentionList()
        {
            return hashtagAndMentionChecker.getMentionList();
        }

        public Dictionary<string,int> getTrendingList()
        {
            return hashtagAndMentionChecker.getSortedTrendingList();
        }

        public LinkedList<string> getQuarantineList()
        {
            return quarantineChecker.getQuarantineList();
        }

        public LinkedList<string> getSIRList()
        {
            return sirList;
        }

        public void saveMessagesToFile()
        {
            string json = JsonConvert.SerializeObject(messageList.ToArray());

            //write string to file
            File.WriteAllText(@"H:\nbmCoursework\nbmCoursework\json_output\json_output_messages", json);
        }

    }
}
