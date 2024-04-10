using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorldTravelTour2024.Core.Models.Traveller
{
    public class BecomeTravellerFormModel
    {
        public int Id { get; set; }
        [Required]        
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public int Age { get; set; }
        [Required]
        public decimal Money { get; set; }
    }
}
