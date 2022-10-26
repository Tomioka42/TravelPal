using System.Collections.Generic;
using TravelPal.Enums;

namespace TravelPal.Models
{
    internal class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
        public List<Travel> Travels { get; set; }
    }
}
