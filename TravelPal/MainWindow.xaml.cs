using System.Windows;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager;
        public MainWindow()
        {
            InitializeComponent();

            this.userManager = new();
        }

        public MainWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager);

            registerWindow.Show();

            Close();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isFoundUser = false;

            foreach (User user in userManager.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    isFoundUser = true;

                    userManager.SignedInUser = user;

                    TravelsWindow travelsWindow = new(userManager);

                    travelsWindow.Show();

                    Close();
                }
                else if (!isFoundUser)
                {
                    MessageBox.Show("Username or password is incorrect", "Warning");
                }
            }




        }
    }
}
