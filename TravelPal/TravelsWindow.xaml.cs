using System.Windows;
using System.Windows.Controls;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;

        public TravelsWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            this.travelManager = new();

            UpdateUI();
        }

        public TravelsWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;

            UpdateUI();
        }

        private void UpdateUI()
        {
            // Uppdatera Ui

            lvDisplay.Items.Clear();

            //txtUserName.Text = this.user.UserName;

            if (this.userManager.SignedInUser is User)
            {
                User signedInUser = this.userManager.SignedInUser as User;

                foreach (var travel in signedInUser.Travels)
                {
                    ListViewItem item = new();
                    item.Content = travel.GetInfo();
                    item.Tag = travel;

                    lvDisplay.Items.Add(item);
                }
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvDisplay.SelectedItem as ListViewItem;

            if (selectedItem != null)
            {
                Travel selectedTravel = selectedItem.Tag as Travel;

                // Ta Bort Resan
                travelManager.RemoveTravel(selectedTravel);

                if (userManager.SignedInUser is User)
                {
                    User signedInUser = userManager.SignedInUser as User;

                    signedInUser.Travels.Remove(selectedTravel);

                    userManager.SignedInUser = signedInUser;
                }

                UpdateUI();
            }
            else
            {
                MessageBox.Show("Please select a travel first!");
            }
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvDisplay.SelectedItem as ListViewItem;

            if (selectedItem != null)
            {
                Travel selectedTravel = selectedItem.Tag as Travel;

                TravelDetailWindow travelDetailWindow = new TravelDetailWindow(selectedTravel, userManager, travelManager);
                travelDetailWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a travel first!");
            }

            Close();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserDeatilsWindow userDeatilsWindow = new(userManager);
            userDeatilsWindow.Show();

            Close();
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(userManager, travelManager);

            mainWindow.Show();
            Close();
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new(userManager, travelManager);

            addTravelWindow.Show();

            Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Travel Pal är ett rese företag som har ambitionerna att hjälpa sina kunder att underlätta sitt resebokande!" +
                "Du kan se dina resor i fönstret till vänster.. Du kan använda dom olika knapparna för att aktivera den önskade funktionen!");
        }

        private void lvDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.IsEnabled = true;
            btnDetails.IsEnabled = true;
        }
    }
}
