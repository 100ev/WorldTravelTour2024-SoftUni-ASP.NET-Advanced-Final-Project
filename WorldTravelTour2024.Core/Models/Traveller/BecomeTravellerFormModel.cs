using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static WorldTravelTour2024.Infrastructure.Constants.DataConstants;


namespace WorldTravelTour2024.Core.Models.Traveller
{
    public class BecomeTravellerFormModel
    {
        [Required]
        [Display(Name = "Id of the traveller")]
        public int Id { get; set; }
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(FirstNameMaxLength,
           MinimumLength = FirstNameMinLength)]
        [Display(Name = "First name of the traveller")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(LastNameMaxLength,
           MinimumLength = LastNameMinLength)]
        [Display(Name = "Last name of the traveller")]
        public string LastName { get; set; } = null!;
        [StringLength(PhoneNumberMaxLength)]
        [Display(Name = "Phone number of traveller")]
        public string PhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [Display(Name = "Age of the traveller")]
        public int Age { get; set; }
        [Required(ErrorMessage = FieldRequiredError)]
        [Display(Name = "The money of the traveller")]
        public decimal Money { get; set; }
    }
}
