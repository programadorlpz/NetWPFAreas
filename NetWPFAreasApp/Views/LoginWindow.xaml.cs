using NetWPFAreasApp.Services;
using NetWPFAreasApp.Customized;
using System.Windows;

namespace NetWPFAreasApp.Views
{
    public partial class LoginWindow : Window
    {
        private AuthenticationService _authService;

        public LoginWindow()
        {
            InitializeComponent();
            _authService = new AuthenticationService();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string role = _authService.Authenticate(username, password);

            if (role != null)
            {
                if (role == "admin")
                {
                    var adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
                else
                {
                    var analystWindow = new AnalystWindow(username);
                    analystWindow.Show();
                }
                this.Close();
            }
            else
            {
                //MessageBox.Show("Usuario o contraseña incorrectos");
                var customMessageBox = new MessageBoxCustom("Usuario o contraseña incorrectos");
                customMessageBox.ShowDialog();
            }
        }
    }
}
