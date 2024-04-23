using System.ComponentModel.DataAnnotations;

namespace WorldTravelTour2024.Core.Models.Destinations
{
    public class CountryIsInContinentFormModel
    {
        [Display(Name = "Name of the country")]
        public string Country { get; set; } = string.Empty;
        [Display(Name = "Name of the continent")]
        public string Continent { get; set; } = string.Empty;
    }
}
