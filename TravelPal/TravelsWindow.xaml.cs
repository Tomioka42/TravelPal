using System.Collections.Generic;
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
        private Travel travel;
        private List<IUser> Users = new();
        private List<Travel> Travels;

        public TravelsWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            UpdateUI();
        }

        private void UpdateUI()
        {
            // Uppdatera Ui

            //txtUserName.Text = this.user.UserName;

            if (this.userManager.SignedInUser is User)
            {
                User signedInUser = this.userManager.SignedInUser as User;

                foreach (var travel in signedInUser.Travels)
                {
                    lvDisplay.Items.Add(travel.GetInfo());
                    ListViewItem item = new();
                    item.Content = travel.GetInfo();
                    item.Tag = travel;
                }
            }
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
