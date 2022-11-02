using System;
using System.Collections.Generic;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class TravelManager
    {
        public List<Travel> AllTravels { get; set; } = new();

        //Metoden för att Lägga till resan i All Travels listan om det är en trip och inte en vacation
        public Travel AddTravel(int travelers, Countries country, string destination, TripTypes tripType)
        {
            Trip trip = new(travelers, country, destination, tripType);

            AllTravels.Add(trip);

            return trip;
        }

        //Metoden för att Lägga till resan i All Travels listan om det är en vacation och inte en trip
        public Travel AddTravel(int travelers, Countries country, string destination, bool allInclusive)
        {
            Vacation vacation = new(travelers, country, destination, allInclusive);

            AllTravels.Add(vacation);

            return vacation;
        }

        //Metoden för att ta bort resan från All travels listan, om den finns i AllTravels
        public void RemoveTravel(Travel travelToRemove)
        {
            try
            {
                if (AllTravels.Contains(travelToRemove))
                {
                    AllTravels.Remove(travelToRemove);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
