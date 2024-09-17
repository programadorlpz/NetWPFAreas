using NetWPFAreasApp.Models;
using NetWPFAreasApp.Services;
using System.Windows;

namespace NetWPFAreasApp.Views
{
    public partial class AnalystWindow : Window
    {
        private AreasService _areasService;
        private AuthenticationService _authService;
        private string _currentUsername;

        public AnalystWindow(string username)
        {
            InitializeComponent();
            _areasService = new AreasService();
            _authService = new AuthenticationService();
            _currentUsername = username;
            CurrentUserTextBlock.Text = _currentUsername;

            LoadAreas();
            LoadCurrentUserArea();
        }

        private void LoadAreas()
        {
            var areas = _areasService.GetAllAreas();
            AreasListBox.ItemsSource = areas;
        }

        private void LoadCurrentUserArea()
        {
            var areaName = _areasService.GetUserArea(_currentUsername);
            CurrentAreaTextBlock.Text = areaName ?? "Ninguna";
        }

        private void AssignAreaButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedArea = AreasListBox.SelectedItem as Area;
            if (selectedArea != null)
            {
                _areasService.AssignUserToArea(_currentUsername, selectedArea.Name);
                LoadCurrentUserArea();
                MessageBox.Show($"Área asignada: {selectedArea.Name}", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un área.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
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
