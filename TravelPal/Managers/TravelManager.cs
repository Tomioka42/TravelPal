using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class TravelManager : Travel
    {
        public List<Travel> Travels { get; set; }
        public TravelManager(int travelers, Countries country, string destination, List<Travel> travels) : base(travelers, country, destination)
        {
            this.Travels = travels;
        }

        public void AddTravel(Travel travel)
        {

        }

        public void RemoveTravel(Travel travel)
        {

        }
    }
}
