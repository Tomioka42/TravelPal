using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Travel
    {
        private int travelers;
        private Countries selectedCountry;

        public Countries Country { get; set; }
        public int Travelers { get; set; }
        public string Destination { get; set; }

        public Travel(int travelers, Countries country, string destination)
        {
            this.Travelers = travelers;
            this.Country = country;
            this.Destination = destination;
        }

        public virtual string GetInfo()
        {
            return $"{Country}";
        }

        public virtual string GetTravelType()
        {
            return "TravelType";
        }
    }
}
