using System.Windows;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailWindow.xaml
    /// </summary>
    public partial class TravelDetailWindow : Window
    {
        private Travel travel;
        public TravelDetailWindow(Travel travel)
        {
            InitializeComponent();

            this.travel = travel;

            UpdateDetails();
        }

        private void UpdateDetails()
        {
            lbDestination.Content = travel.Destination;
            lbCountry.Content = travel.Country;
            lbAmountOfTravelers.Content = travel.Travelers;
            lbTravelType.Content = travel.GetTravelType();


        }
    }
}
