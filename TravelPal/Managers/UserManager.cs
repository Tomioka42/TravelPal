using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models;


namespace TravelPal.Managers
{
    public class UserManager : IUser
    {
        private List<Travel> Travels;
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
        public List<IUser> Users { get; set; } = new();
        public IUser SignedInUser { get; set; }

        public UserManager()
        {
            this.Users = Users;


            AddGandalf();
            //AddAdmin();
        }
        public bool AddUser(string username, string password, Countries country)
        {
            // Validate username
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

        //public void RemoveUser(IUser user)
        //{

        //}

        public bool UpdateUsername(IUser user, string username)
        {
            return false;
        }

        // Denna metod checkar om username är valid eller inte.
        private bool ValidateUsername(string username)
        {
            bool isInvalidUsername = false;

            foreach (User user in Users)
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
        private void AddAdmin()
        {
            Admin admin = new("Admin", "password", Enums.Countries.Korea);

            Users.Add(admin);
        }

        private void AddGandalf()
        {
            User user = new("Gandalf", "password", Enums.Countries.Sweden);
            Users.Add(user);

            Vacation vacation1 = new(2, Enums.Countries.United_Kingdom, "London", false);
            user.Travels.Add(vacation1);

            Trip trip1 = new(1, Enums.Countries.Korea, "Seoul", TripTypes.Work);
            user.Travels.Add(trip1);
        }

        public List<IUser> GetAllUsers()
        {
            return Users;
        }
    }
}
