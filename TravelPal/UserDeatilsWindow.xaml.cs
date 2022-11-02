using System;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDeatilsWindow.xaml
    /// </summary>
    public partial class UserDeatilsWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;
        public UserDeatilsWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;

            cbNewCountry.ItemsSource = Enum.GetNames(typeof(Countries));

            lbCurrentUsername.Content = userManager.SignedInUser.Username;

            lbCurrentPassword.Content = userManager.SignedInUser.Password;

            lbCurrentCountry.Content = userManager.SignedInUser.Location;
        }

        //Öppnar Travels window och stänger user details window
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();

            Close();
        }

        //Öppnar Travels window och stänger user details window
        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();

            Close();
        }

        //CLick event som ändrar username på användaren
        private void btnChangeUsername_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewUsername.Text != null && txtNewUsername.Text.Length >= 3)
            {
                if (txtNewUsername.Text == userManager.Username)
                {
                    MessageBox.Show("This username is already in use please try another");
                }
                else
                {
                    string newUsername = txtNewUsername.Text;

                    userManager.SignedInUser.Username = newUsername;

                    lbCurrentUsername.Content = userManager.SignedInUser.Username;
                }
            }
        }

        //CLick event som ändrar password på användaren
        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewPassword != null && txtNewPassword.Text == txtConfirmPassword.Text && txtNewPassword.Text.Length >= 5)
            {
                string newPassword = txtNewPassword.Text;

                userManager.SignedInUser.Password = newPassword;

                lbCurrentPassword.Content = userManager.SignedInUser.Password;
            }
            else
            {
                MessageBox.Show("The new password don't match the confirm password, Try again");
            }
        }

        //CLick event som ändrar location på användaren
        private void btnChangeCountry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbNewCountry.SelectedItem != null)
                {
                    string newCountry = cbNewCountry.SelectedItem.ToString();

                    Countries Country = (Countries)Enum.Parse(typeof(Countries), newCountry);

                    userManager.SignedInUser.Location = Country;

                    lbCurrentCountry.Content = userManager.SignedInUser.Location;
                }
            }
            catch (ArgumentNullException anex)
            {
                MessageBox.Show(anex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
