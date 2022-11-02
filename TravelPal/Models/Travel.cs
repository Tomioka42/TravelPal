using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Travel
    {

        public Countries Country { get; set; }
        public int Travelers { get; set; }
        public string Destination { get; set; }

        public Travel(int travelers, Countries country, string destination)
        {
            this.Travelers = travelers;
            this.Country = country;
            this.Destination = destination;
        }

        //Virtual metoden för att hämta vilket country resan är.
        public virtual string GetInfo()
        {
            return $"{Country}";
        }

        //Virtual metoden för att hämta vilken typ resan är (Vacation eller Trip)
        public virtual string GetTravelType()
        {
            return "TravelType";
        }

        //Virtual metoden för att hämta vilken typ eller om den har AllInclusive (Vacation = All inclusive true or false) (Trip = Work eller leisure)
        public virtual string GetTravelInfo()
        {
            return "TravelInfo";
        }
    }
}
