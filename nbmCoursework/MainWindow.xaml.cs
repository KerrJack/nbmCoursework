using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using nbmCoursework.Messages;

namespace nbmCoursework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // if statment used to check that the message header is not left blank before submitting
            if (string.IsNullOrEmpty(MessageHeaderTextBox.Text))
            {
                MessageBox.Show("Message Header cannot be left blank. please enter a message header.");
            }

            // initialising the id string to count how many characters have been inputted
            string header = MessageHeaderTextBox.Text;

            int count = 0;

            for (int i = 0; i < header.Length; i++)
            {
                count++;
            }

            // if the count is not equal to 10 then the user will be given an error message and asked to input a valid message header
            if (count != 10)
            {
                MessageBox.Show("Message Header is only 10 characters long. please enter a valid message header");
            }

            // if the message header begins with the letter E then a new email object will be created
            if (MessageHeaderTextBox.Text.StartsWith("E"))
            {
                string[] lines = Regex.Split(MessageBodyTextBox.Text, "\r\n");
                Email newEmail = new Email(MessageHeaderTextBox.Text, MessageHeaderTextBox.Text[0], lines[2], lines[0], lines[1]);

                return;
            }

            // if the message header begins with the letter S then a new SMS object will be created
            else if (MessageHeaderTextBox.Text.StartsWith("S"))
            {
                string[] lines = Regex.Split(MessageBodyTextBox.Text, "\r\n");

                SMS newSMS = new SMS(MessageHeaderTextBox.Text, MessageHeaderTextBox.Text[0], lines[1], lines[0]);


                string smsMessage = lines[1];

                int smsCharacterCount = 0;

                for (int i = 0; i < smsMessage.Length; i++)
                {
                    count++;
                }

                if (smsCharacterCount > 140)
                {
                    MessageBox.Show("Message can only be 140 characters long");
                }

                return;
            }

            // if the message header begins with the letter T then a new Tweet object will be created
            else if (MessageHeaderTextBox.Text.StartsWith("T"))
            {
                string[] lines = Regex.Split(MessageBodyTextBox.Text, "\r\n");

                Tweet newTweet = new Tweet(MessageHeaderTextBox.Text, MessageHeaderTextBox.Text[0], lines[1], lines[0]);

                return;
            }

            else
            {
                MessageBox.Show("Header must begin with S, E or T");
            }


        }
    }
}
