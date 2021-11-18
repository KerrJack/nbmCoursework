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

            if (string.IsNullOrEmpty(MessageHeaderTextBox.Text))
            {
                MessageBox.Show("Message Header cannot be left blank. please enter a message header.");
            }

         
            if (MessageHeaderTextBox.Text.StartsWith("E"))
            {
                string[] lines = Regex.Split(MessageBodyTextBox.Text, "\r\n");
                Email newEmail = new Email(MessageHeaderTextBox.Text, MessageHeaderTextBox.Text[0], lines[2], lines[0], lines[1]);

                return;
            }

            if (MessageHeaderTextBox.Text.StartsWith("S"))
            {
                string[] lines = Regex.Split(MessageBodyTextBox.Text, "\r\n");

                SMS newSMS = new SMS(MessageHeaderTextBox.Text, MessageHeaderTextBox.Text[0], lines[1], lines[0]);

                return;
            }

            if (MessageHeaderTextBox.Text.StartsWith("T"))
            {
                string[] lines = Regex.Split(MessageBodyTextBox.Text, "\r\n");

                Tweet newTweet = new Tweet(MessageHeaderTextBox.Text, MessageHeaderTextBox.Text[0], lines[1], lines[0]);

                return;
            }


        }
    }
}
