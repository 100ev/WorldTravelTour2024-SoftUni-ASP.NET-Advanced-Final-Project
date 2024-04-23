using System.ComponentModel.DataAnnotations;
using static WorldTravelTour2024.Infrastructure.Constants.DataConstants;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace WorldTravelTour2024.Core.Models.Agent
{
    public class ReservationCreatedFormModel
    {
        [Display(Name = "Id of the Host")]
        public int HostId { get; set; }
        [Display(Name = "Id of the Host")]
        public int TravellerId { get; set; }        
        [Display(Name = "Address of the reservation")]
        public string Address { get; set; } = string.Empty;
        [Display(Name = "The number of travellers")]
        public int NumberOfTravellers { get; set; }
        [Display(Name = "Number of nights that the traveller will stay")]
        public int NumberOfNigths { get; set; }
        [Display(Name = "Number of rooms that the Host can provide")]
        public int NumberOfRooms { get; set; }
    }
}
