using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WorldTravelTour2024.Infrastructure.Constants.DataConstants;

namespace WorldTravelTour2024.Core.Models.CountryInformationAdvisor
{
    public class CountryInformationFormModel
    {
        [Required]
        [Display(Name = "Id of the Country Inofrmation Advisor")]
        public int Id { get; set; }
        [Required]
        [StringLength(UserRequestingInformationAboutCountryNameMaxLength)]
        [Display(Name = "Full name of the user that requires information reagrding country")]
        public string UserToAssist { get; set; } = null!;
        [Required]
        [Display(Name = "Name of the country that the user requires information about")]
        public string Country { get; set; } = null!;
        [Required]
        [Display(Name = "Information about the country")]
        public string Description { get; set; } = null!;

    }
}
