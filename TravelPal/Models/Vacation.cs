using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(int travelers, Countries country, string destination, bool allInclusive) : base(travelers, country, destination)
        {
            AllInclusive = allInclusive;
        }

        //Override metoden för att hämta vilket land det är om det är en trip
        public override string GetInfo()
        {
            return $"{Country}";
        }

        //Override metoden för att visa att resan är en Vacation och inte en trip
        public override string GetTravelType()
        {
            return "Vacation";
        }

        //Override metoden för att visa om det är all inclusive eller inte
        public override string GetTravelInfo()
        {
            if (AllInclusive)
            {
                return $"Have AllInclusive";
            }
            else
            {
                return "Doesn't have AllInculsive";
            }

        }
    }
}
