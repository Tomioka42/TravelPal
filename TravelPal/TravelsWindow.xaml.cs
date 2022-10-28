using System.Windows;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private UserManager userManager;

        public TravelsWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new(userManager);

            addTravelWindow.Show();

            Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Travel Pal är ett rese företag som har ambitionerna att hjälpa sina kunder att underlätta sitt resebokande!" +
                "Du kan se dina resor i fönstret till vänster.. Du kan använda dom olika knapparna för att aktivera den önskade funktionen!");
        }
    }
}
