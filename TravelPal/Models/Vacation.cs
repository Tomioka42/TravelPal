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
    }
}
