using System.ComponentModel.DataAnnotations;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Core.Models.TransportationProvider
{
    public class BecomeTransportationProvider
    {
        public string FirstName { get; set; } = null!;        
        public string LastName { get; set; } = null!;
       
        public string PhoneNumber { get; set; } = null!;

        public List<Country> Countries = new List<Country>();
    }
}
