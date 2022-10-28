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

        public List<Travel> Travels { get; set; }
        public IUser SignedInUser { get; set; }

        public UserManager()
        {
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

        public void RemoveUser(IUser user)
        {

        }

        public bool UpdateUsername(IUser user, string username)
        {
            return false;
        }

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

        public bool SignInUser(string username, string password)
        {
            return false;
        }
    }
}
