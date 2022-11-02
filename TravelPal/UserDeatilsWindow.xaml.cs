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
        public UserDeatilsWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            cbNewCountry.ItemsSource = Enum.GetNames(typeof(Countries));

            lbCurrentUsername.Content = userManager.SignedInUser.Username;

            lbCurrentPassword.Content = userManager.SignedInUser.Password;

            lbCurrentCountry.Content = userManager.SignedInUser.Location;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager);
            travelsWindow.Show();

            Close();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new(userManager);
            travelsWindow.Show();

            Close();
        }

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

        private void btnChangeCountry_Click(object sender, RoutedEventArgs e)
        {
            if (cbNewCountry.SelectedItem != null)
            {
                string newCountry = cbNewCountry.SelectedItem.ToString();

                Countries Country = (Countries)Enum.Parse(typeof(Countries), newCountry);

                userManager.SignedInUser.Location = Country;

                lbCurrentCountry.Content = userManager.SignedInUser.Location;
            }

        }
    }
}


//if (txtNewUsername.Text.Length >= 2)
//{
//    if (txtNewUsername.Text != userManager.Username)
//    {
//        user.Username = txtNewUsername.Text;
//    }
//    else
//    {
//        MessageBox.Show("This username is already in use, please choose another");
//    }
//}

//if (txtNewPassword != null && txtNewPassword == txtConfirmPassword && txtNewPassword.Text.Length >= 5)
//{
//    user.Password = txtNewPassword.Text;
//}
//else
//{
//    MessageBox.Show("The new password don't match the confirm password, Try again");
//}



//TravelsWindow travelsWindow = new(userManager);
//travelsWindow.Show();

//Close();
