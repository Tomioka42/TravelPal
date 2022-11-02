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

        public override string GetInfo()
        {
            return $"{Country}";
        }

        public override string GetTravelType()
        {
            return "Vacation";
        }

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
