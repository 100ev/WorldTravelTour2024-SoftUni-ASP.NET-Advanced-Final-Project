using System.ComponentModel.DataAnnotations;
using static WorldTravelTour2024.Infrastructure.Constants.DataConstants;

namespace WorldTravelTour2024.Core.Models.Destinations
{
    public class ContinetIsVisitableFormModel
    {
        [Display(Name = "Id of the continent")]
        public int ContinentId { get; set; }
        [Display(Name = "Id of the traveller")]
        public int TravellerId { get; set; }
        [Display(Name = "Season in the continent")]
        public string Season { get; set; } = string.Empty;
    }
}
