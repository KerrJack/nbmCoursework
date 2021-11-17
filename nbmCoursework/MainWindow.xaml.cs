using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Message newMessage = new Message(MessageHeaderTextBox.Text, MessageHeaderTextBox.Text[0], MessageBodyTextBox.Text);
            return;
        }
    }
}
