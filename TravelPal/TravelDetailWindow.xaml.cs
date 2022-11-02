using System.Windows;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailWindow.xaml
    /// </summary>
    public partial class TravelDetailWindow : Window
    {
        private Travel travel;
        private UserManager userManager;
        private TravelManager travelManager;
        public TravelDetailWindow(Travel travel, UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.travel = travel;
            this.userManager = userManager;
            this.travelManager = travelManager;

            UpdateDetails();
        }

        //Uppdaterar all information om resan till travel details window
        private void UpdateDetails()
        {
            lbDestination.Content = travel.Destination;
            lbCountry.Content = travel.Country;
            lbAmountOfTravelers.Content = travel.Travelers;
            lbTravelType.Content = travel.GetTravelType();
            lbTravelInfo.Content = travel.GetTravelInfo();


        }

        //Click event som öppnar travels window och stänger travel details window om användaren trycker på back knappen
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();

            Close();
        }
    }
}
