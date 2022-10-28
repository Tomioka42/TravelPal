using System;
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
        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            cbCountries.ItemsSource = Enum.GetNames(typeof(Countries));
        }
        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {

            // Fixa att om alla inte är inlagda och skrivna så blir det ett error meddelande
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string country = cbCountries.SelectedItem as string;



            if (cbCountries.SelectedItem == null || txtUsername.Text == null || txtPassword.Text == null)
            {
                MessageBox.Show("Error! You must enter all the information that is asked");
            }
            else
            {
                Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

                this.userManager.AddUser(username, password, selectedCountry);

                MainWindow mainWindow = new(userManager);

                mainWindow.Show();

                Close();
            }

        }
    }
}
