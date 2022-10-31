using System;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDeatilsWindow.xaml
    /// </summary>
    public partial class UserDeatilsWindow : Window
    {
        private User user;
        private UserManager userManager;
        public UserDeatilsWindow(UserManager userManager)
        {
            InitializeComponent();

            //lbCurrentUsername.Content

            cbNewCountry.ItemsSource = Enum.GetNames(typeof(Countries));

            lbCurrentUsername.Content = userManager.SignedInUser.Username;

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

        }

        private void btnChangeUsername_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewUsername.Text != null)
            {
                user.Username = txtNewUsername.Text;
            }
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

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

//if (cbNewCountry.SelectedItem != null)
//{
//    cbNewCountry.SelectedItem = user.Location.ToString();
//}

//TravelsWindow travelsWindow = new(userManager);
//travelsWindow.Show();

//Close();
