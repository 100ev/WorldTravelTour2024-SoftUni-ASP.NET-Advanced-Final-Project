using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WorldTravelTour2024.Infrastructure.Constants.DataConstants;

namespace WorldTravelTour2024.Infrastructure.Data.Models
{
    public class TransportationProvider
    {
        [Key]
        [Comment("Transportation Provider Id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("Transportation Provider First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("Transportation Provider Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Transportation Provider Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(CountryToTransportGuestNameMaxLength)]
        [Comment("Name of the country where the guest must pe transported")]
        public string CountryNameToTransportGuest { get; set; } = string.Empty;        
        public IEnumerable<Country> Countries = new List<Country>();
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        [Comment("The profit from the transportations of guests")]
        public decimal Profit { get; set; }
        public IdentityUser User { get; set; } = null!;

    }
}
