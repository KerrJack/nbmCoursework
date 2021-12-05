using System;
using System.Collections;
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
        private NBMManager nbmManager;
        private TextAbbreviationChecker checker;
        public MainWindow()
        {
            InitializeComponent();

            nbmManager = new NBMManager();

            checker = new TextAbbreviationChecker();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            Boolean validated = true;

            // if statment used to check that the message header is not left blank before submitting
            if (string.IsNullOrEmpty(MessageHeaderTextBox.Text))
            {
                MessageBox.Show("Message Header cannot be left blank. please enter a message header.");
                validated = false;
            }

            if (string.IsNullOrEmpty(MessageBodyTextBox.Text))
            {
                MessageBox.Show("Message Body cannot be left blank. please enter a message body.");
                validated = false;
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
                validated = false;
            }



            if (validated)
            {
                string processMessageResult = nbmManager.processMessage(MessageHeaderTextBox.Text, MessageBodyTextBox.Text);

                if (processMessageResult != "SUCCESS")
                {
                    MessageBox.Show(processMessageResult);
                }
                else
                {
                    MessageHeaderTextBox.Text = String.Empty;
                    MessageBodyTextBox.Text = String.Empty;
                    MessageBox.Show("Submitted");
                }
            }
            
        }

        private void hashtagListButton_Click(object sender, RoutedEventArgs e)
        {
            nbmManager.displayHashTagList();

            foreach (string hashtag in nbmManager.getHashtagList())
            {
                hashtagReportBox.AppendText(hashtag);
            }
            
        }
    }
}
