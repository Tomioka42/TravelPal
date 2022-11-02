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

        //Override metoden för att hämta vilket land det är om det är en trip
        public override string GetInfo()
        {
            return $"{Country}";
        }

        //Override metoden för att visa att resan är en trip och inte en vacation
        public override string GetTravelType()
        {
            return "Trip";
        }

        //Override metoden för att visa om det är en work trip eller en leisure trip
        public override string GetTravelInfo()
        {
            return $"{Type}";
        }
    }
}
