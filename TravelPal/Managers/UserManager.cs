using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models;


namespace TravelPal.Managers
{
    public class UserManager : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
        public List<IUser> Users { get; set; } = new();
        public IUser SignedInUser { get; set; }

        public UserManager()
        {
            this.Users = Users;


            AddGandalf();
            AddAdmin();
        }

        //Metoden för att Adda en user till Users listan
        public bool AddUser(string username, string password, Countries country)
        {
            if (ValidateUsername(username))
            {
                User user = new(username, password, country);

                Users.Add(user);

                return true;
            }
            else
            {
                return false;
            }
        }

        //Metoden för att kunna uppdatera sitt username i applikationen
        public bool UpdateUsername(IUser user, string username)
        {
            return false;
        }

        //Metoden för att kunna titta om usernamet är valid eller om det redan används av en annan user
        private bool ValidateUsername(string username)
        {
            bool isInvalidUsername = false;

            foreach (IUser user in Users)
            {
                if (user.Username == username)
                {
                    isInvalidUsername = true;
                }
            }

            if (!isInvalidUsername)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Metoden som skapar Admin användaren
        private void AddAdmin()
        {
            Admin admin = new("Admin", "password", Enums.Countries.Korea);

            Users.Add(admin);
        }

        //Metoden som skapar Gandalf avändaren och skapar två resor till användaren
        private void AddGandalf()
        {
            User user = new("Gandalf", "password", Enums.Countries.Sweden);
            Users.Add(user);

            Vacation vacation1 = new(2, Enums.Countries.United_Kingdom, "London", false);
            user.Travels.Add(vacation1);

            Trip trip1 = new(1, Enums.Countries.Korea, "Seoul", TripTypes.Work);
            user.Travels.Add(trip1);
        }
    }
}
