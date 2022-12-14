using System;
using System.Linq;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;
        public RegisterWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;

            cbCountries.ItemsSource = Enum.GetNames(typeof(Countries));
        }
        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string country = cbCountries.SelectedItem as string;

            try
            {
                if (country.Count() == 0 || username.Count() == 0 || password.Count() == 0)
                {

                    MessageBox.Show("Error! You must enter all the information that is asked");
                }
                else
                {
                    Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

                    if (this.userManager.AddUser(username, password, selectedCountry))
                    {
                        MainWindow mainWindow = new(userManager, travelManager);

                        mainWindow.Show();

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("This username is already in use, please try another");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! You need to enter all the information that is asked for!");
            }
        }
    }
}
