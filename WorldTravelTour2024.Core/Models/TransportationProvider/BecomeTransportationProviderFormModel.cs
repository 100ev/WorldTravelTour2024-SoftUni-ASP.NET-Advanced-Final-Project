using System.ComponentModel.DataAnnotations;
using WorldTravelTour2024.Infrastructure.Data.Models;
using static WorldTravelTour2024.Infrastructure.Constants.DataConstants;

namespace WorldTravelTour2024.Core.Models.TransportationProvider
{
    public class BecomeTransportationProviderFormModel
    {
        [Required]
        [Display(Name = "Id of the transportation provider")]
        public int Id { get; set; }
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(FirstNameMaxLength,
           MinimumLength = FirstNameMinLength)]
        [Display(Name = "First name of the transportation provider")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(LastNameMaxLength,
           MinimumLength = LastNameMinLength)]
        [Display(Name = "Last name of the transportation provider")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(PhoneNumberMaxLength)]
        [Display(Name = "Phone number of transportation provider")]
        public string PhoneNumber { get; set; } = null!;
        [Display(Name = "Countries where the transportation provider can transport travellers to")]
        public List<Country> Countries { get; set; } = new List<Country>();
    }
}
