using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Trip : Travel
    {

        public TripTypes Type { get; set; }
        public Trip(int travelers, Countries country, string destination, TripTypes selectedTripType) : base(travelers, country, destination)
        {
            Type = selectedTripType;
        }
        public override string GetInfo()
        {
            return $"{Country}";
        }

        public override string GetTravelType()
        {
            return "Trip";
        }
    }
}
