﻿using TravelPal.Enums;

namespace TravelPal.Models
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }

        public void IUser(string username, string password, Countries location)
        {

        }
    }
}
