using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        private TravelManager travelManager = new();
        private string selectedTravelType;
        private UserManager userManager;

        public AddTravelWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            cbCountry.ItemsSource = Enum.GetNames(typeof(Countries));

            cbTravelType.ItemsSource = Enum.GetNames(typeof(TravelTypes));

            cbTripType.ItemsSource = Enum.GetNames(typeof(TripTypes));
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            string destination = txtDestination.Text;
            string travelers = txtAmountOfTravelers.Text;



            try
            {
                int travelersInt = int.Parse(travelers);

                string country = cbCountry.SelectedItem as string;

                Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

                if (selectedTravelType == "Trip")
                {
                    string tripType = cbTripType.SelectedItem as string;

                    TripTypes selectedTripType = (TripTypes)Enum.Parse(typeof(TripTypes), tripType);

                    Travel newTravel = travelManager.AddTravel(travelersInt, selectedCountry, destination, selectedTripType);

                    User user = userManager.SignedInUser as User;

                    user.Travels.Add(newTravel);
                }
                else if (selectedTravelType == "Vacation")
                {
                    bool allInclusive = (bool)xbAllInclusive.IsChecked;

                    Travel newTravel = travelManager.AddTravel(travelersInt, selectedCountry, destination, allInclusive);

                    User user = userManager.SignedInUser as User;

                    user.Travels.Add(newTravel);

                }
                TravelsWindow travelsWindow = new(userManager);

                travelsWindow.Show();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }

        }


        private void cbTravelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Trip eller Vacation?
            this.selectedTravelType = cbTravelType.SelectedItem as string;

            if (selectedTravelType == "Trip")
            {
                // Visa leisure or work combobox
                cbTripType.Visibility = Visibility.Visible;
                xbAllInclusive.Visibility = Visibility.Hidden;
            }
            else if (selectedTravelType == "Vacation")
            {
                // Visa all inclusive checkbox
                cbTripType.Visibility = Visibility.Hidden;
                xbAllInclusive.Visibility = Visibility.Visible;
            }
        }
    }
}
