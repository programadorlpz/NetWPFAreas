using NetWPFAreasApp.Models;
using NetWPFAreasApp.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NetWPFAreasApp.Views
{
    public partial class AdminWindow : Window
    {
        private AuthenticationService _authService;
        private User _selectedUser;

        public AdminWindow()
        {
            InitializeComponent();
            _authService = new AuthenticationService();
            RoleComboBox.SelectedIndex = 0; // Selecciona el primer rol por defecto
            LoadUsers();
        }

        private void LoadUsers()
        {
            var lastUsers = _authService.GetLastUsers(10);
            UsersDataGrid.ItemsSource = lastUsers;
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newUser = new User
                {
                    Username = UsernameTextBox.Text.Trim(),
                    Password = UserPasswordBox.Password,
                    Role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Email = EmailTextBox.Text.Trim(),
                    PhoneNumber = PhoneNumberTextBox.Text.Trim(),
                    CreatedAt = DateTime.Now
                };

                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(newUser.Username) ||
                    string.IsNullOrWhiteSpace(newUser.Password) ||
                    string.IsNullOrWhiteSpace(newUser.Role))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _authService.AddUser(newUser);
                LoadUsers();
                ClearCreateUserForm();
                MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearCreateUserForm()
        {
            UsernameTextBox.Text = string.Empty;
            UserPasswordBox.Password = string.Empty;
            RoleComboBox.SelectedIndex = 0;
            EmailTextBox.Text = string.Empty;
            PhoneNumberTextBox.Text = string.Empty;
        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedUser = UsersDataGrid.SelectedItem as User;
            if (_selectedUser != null)
            {
                EditEmailTextBox.Text = _selectedUser.Email;
                EditPhoneNumberTextBox.Text = _selectedUser.PhoneNumber;
                UpdateUserButton.IsEnabled = true;
            }
            else
            {
                EditEmailTextBox.Text = string.Empty;
                EditPhoneNumberTextBox.Text = string.Empty;
                UpdateUserButton.IsEnabled = false;
            }
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUser != null)
            {
                try
                {
                    _selectedUser.Email = EditEmailTextBox.Text.Trim();
                    _selectedUser.PhoneNumber = EditPhoneNumberTextBox.Text.Trim();

                    _authService.UpdateUser(_selectedUser);
                    LoadUsers();
                    MessageBox.Show("Datos de contacto actualizados.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar usuario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
