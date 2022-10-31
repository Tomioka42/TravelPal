using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class TravelManager
    {
        public List<Travel> AllTravels { get; set; } = new();

        public Travel AddTravel(int travelers, Countries country, string destination, TripTypes tripType)
        {
            Trip trip = new(travelers, country, destination, tripType);

            AllTravels.Add(trip);

            return trip;
        }

        public Travel AddTravel(int travelers, Countries country, string destination, bool allInclusive)
        {
            Vacation vacation = new(travelers, country, destination, allInclusive);

            AllTravels.Add(vacation);

            return vacation;
        }

        public void RemoveTravel(Travel travelToRemove)
        {
            Travel foundTravel = null;

            foreach (Travel travel in AllTravels)
            {
                if (travel is Travel)
                {
                    Travel travels = travel as Travel;

                    if (travels.Country == travelToRemove.Country)
                    {
                        foundTravel = travels;
                    }
                }
            }

            if (foundTravel != null)
            {
                AllTravels.Remove(foundTravel);
            }
        }
    }
}
