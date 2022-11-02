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
        private TravelManager travelManager;
        public MainWindow()
        {
            InitializeComponent();

            this.userManager = new();
            this.travelManager = new();

            foreach (IUser user in userManager.Users)
            {
                if (user is User)
                {
                    User u = user as User;

                    travelManager.AllTravels.AddRange(u.Travels);
                }
            }
        }

        public MainWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager, travelManager);

            registerWindow.Show();

            Close();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isFoundUser = false;

            foreach (IUser user in userManager.Users)
            {

                if (user.Username == username && user.Password == password)
                {
                    isFoundUser = true;

                    userManager.SignedInUser = user;

                    TravelsWindow travelsWindow = new(userManager, travelManager);

                    travelsWindow.Show();

                    Close();
                }
            }


            if (!isFoundUser)
            {
                MessageBox.Show("Username or password is incorrect", "Warning");
            }

        }
    }
}
