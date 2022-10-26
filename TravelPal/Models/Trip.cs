using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Trip : Travel
    {
        public TripTypes Type { get; set; }

        public Trip(int Travelers, Countries Country, string Destination, TripTypes type) : base(Travelers, Country, Destination)
        {
            this.Type = type;
        }

        public override string GetInfo()
        {
            return "";
        }
    }
}
