using System;
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

        public TravelsWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;

            UpdateUI();
        }

        //Metoden som uppdaterar listviewn på travels window och tittar om det är en user eller admin som loggar in
        private void UpdateUI()
        {
            // Uppdatera Ui

            lvDisplay.Items.Clear();

            //txtUserName.Text = this.user.UserName;
            try
            {
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
                else if (this.userManager.SignedInUser is Admin)
                {
                    IUser signedInAdmin = this.userManager.SignedInUser as Admin;

                    foreach (var travel in travelManager.AllTravels)
                    {
                        ListViewItem item = new();
                        item.Content = travel.GetInfo();
                        item.Tag = travel;

                        lvDisplay.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Om Remove knappen aktiveras så kallar den till andra metoder nödvändiga till att ta bort den önskade resan.
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

        //Click event som öppnar travel details window om användaren har valt en resa att visa details på
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

        //Click event som öppnar user details window och stänger travels window
        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserDeatilsWindow userDeatilsWindow = new(userManager, travelManager);
            userDeatilsWindow.Show();

            Close();
        }

        //Loggar ut användaren och öppnar Log in windowet
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(userManager, travelManager);

            mainWindow.Show();
            Close();
        }

        //Öppnar Add travel window och stänger travels window
        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new(userManager, travelManager);

            addTravelWindow.Show();

            Close();
        }

        //Öppnar en message box som visar användaren lite information om företaget samt funktionerna om appen
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Travel Pal är ett rese företag som har ambitionerna att hjälpa sina kunder att underlätta sitt resebokande!" +
                "Du kan se dina resor i fönstret till vänster.. Du kan använda dom olika knapparna för att aktivera den önskade funktionen!");
        }

        //Gör att remove och details knappen funkar om användaren har valt en resa. Dessa knappar är inte enabled annars
        private void lvDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.IsEnabled = true;
            btnDetails.IsEnabled = true;
        }
    }
}
