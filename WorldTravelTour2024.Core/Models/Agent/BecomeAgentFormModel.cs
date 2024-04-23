using System.ComponentModel.DataAnnotations;
using static WorldTravelTour2024.Infrastructure.Constants.DataConstants;

namespace WorldTravelTour2024.Core.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(FirstNameMaxLength,
            MinimumLength = FirstNameMinLength)]
        [Display(Name = "First name of Agent")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(LastNameMaxLength,
            MinimumLength = LastNameMinLength)]
        [Display(Name = "Last name of Agent")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(PhoneNumberMaxLength)]
        [Display(Name = "Phone number of Agent")]
        public string PhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(EmailMaxLength,
            MinimumLength = EmailMinLength)]
        [Display(Name = "Email of Agent")]
        public string Email { get; set; } = null!;
    }
}
