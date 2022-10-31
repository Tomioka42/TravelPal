using System.Windows;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDeatilsWindow.xaml
    /// </summary>
    public partial class UserDeatilsWindow : Window
    {
        private User user;
        public UserDeatilsWindow()
        {
            InitializeComponent();

            lbCurrentUsername.Content = user.Username;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
