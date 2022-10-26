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
        public List<IUser> Users { get; set; }
        public IUser SignedInUser { get; set; }

        public UserManager()
        {

        }
        public bool AddUser(IUser user, string username, string password)
        {
            user.Username = Username;
            user.Password = Password;

            Users.Add(user);
            return false;
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
            return false;
        }

        public bool SignInUser(string username, string password)
        {
            return false;
        }
    }
}
