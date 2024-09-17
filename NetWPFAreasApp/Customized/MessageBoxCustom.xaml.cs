using System.Windows;

namespace NetWPFAreasApp.Customized
{
    public partial class MessageBoxCustom : Window
    {
        public MessageBoxCustom(string message)
        {
            InitializeComponent();
            MessageTextBlock.Text = message;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
