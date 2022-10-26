using System.Windows;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager);

            registerWindow.Show();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
