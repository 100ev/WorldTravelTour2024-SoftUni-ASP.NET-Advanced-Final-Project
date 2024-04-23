using System.ComponentModel.DataAnnotations;
using WorldTravelTour2024.Infrastructure.Data.Models;
using static WorldTravelTour2024.Infrastructure.Constants.DataConstants;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WorldTravelTour2024.Core.Models.Continent
{
    public class ContinentFormModel
    {
        [Required]
        [Display(Name = "Id of continent")]
        public int Id { get; set; }
        [Required]
        [StringLength(ContinentNameMaxLentgh)]
        [Display(Name = "Name of the continent")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Shows if the continent is visible during a specific season of the year")]
        public bool IsVisitableDuringThisSeason { get; set; } = true;
        [Required]
        [Display(Name = "Countries on the continent")]
        public IEnumerable<Country> Countries { get; set; } = new List<Country>();
    }
}
