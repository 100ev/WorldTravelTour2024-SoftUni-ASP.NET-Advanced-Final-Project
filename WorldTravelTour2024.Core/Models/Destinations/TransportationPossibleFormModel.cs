using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace WorldTravelTour2024.Core.Models.Destinations
{
    public class TransportationPossibleFormModel
    {
        [Display(Name = "Id of traveller")]
        public int TravellerId { get; set; }
        [Display(Name = "Id of transportation provider")]
        public int TransportationProviderId { get; set; }
        [Display(Name = "Country where the traveller is going to")]
        public string Destination { get; set; } = string.Empty;
    }
}
