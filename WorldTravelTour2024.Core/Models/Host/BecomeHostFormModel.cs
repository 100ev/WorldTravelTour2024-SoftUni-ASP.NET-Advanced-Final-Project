using System.ComponentModel.DataAnnotations;
using WorldTravelTour2024.Core.Models.Traveller;
using static WorldTravelTour2024.Infrastructure.Constants.DataConstants;

namespace WorldTravelTour2024.Core.Models.Host
{
    public class BecomeHostFormModel
    {
        [Required(ErrorMessage = FieldRequiredError)]
        [Display(Name = "Id of the host")]
        public int Id { get; set; }
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(FirstNameMaxLength,
            MinimumLength = FirstNameMinLength)]
        [Display(Name = "First name of the host")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(LastNameMaxLength,
            MinimumLength = LastNameMinLength)]
        [Display(Name = "Last name of the host")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(EmailMaxLength,
            MinimumLength = EmailMinLength)]
        [Display(Name = "Email of Host")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [Range(typeof(decimal),
            PricePerNightMaxValue,
            PricePerNightMinValue,
            ConvertValueInInvariantCulture = true)]
        [Display(Name = "The price for a single night")]
        public  decimal PricePerNight { get; set; }
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(AddressMaxLength, 
            MinimumLength = AddressMinLength)]
        [Display(Name = "Address of the host")]
        public string Address { get; set; } = null!;
        [Required(ErrorMessage = FieldRequiredError)]
        [StringLength(PhoneNumberMaxLength)]
        [Display(Name = "Phone number of Host")]
        public string PhoneNumber { get; set; } = null!;
        [Display(Name = "Number of travellers that will visit the host")]
        public List<BecomeTravellerFormModel> Travellers { get; set; } = new List<BecomeTravellerFormModel>();
        [Required(ErrorMessage = FieldRequiredError)]
        [Display(Name = "Number of rooms that the host can provide")]
        public int Rooms { get; set; }
        [Display(Name = "The Profit of the host")]
        public decimal Wallet { get; set; }
    }
}
