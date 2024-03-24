using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WorldTravelTour2024.Infrastructure.Constants.DataConstants;

namespace WorldTravelTour2024.Infrastructure.Data.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;
        [Required]
        public string TravellerId { get; set; } = null!;
        [ForeignKey(nameof(TravellerId))]
        public IdentityUser Traveller { get; set; } = null!;
        [Required]
        public string HostId { get; set; } = null!;
        [ForeignKey(nameof(HostId))]
        public IdentityUser Host { get; set; } = null!;
        [Required]
        public string TransportationProviderId { get; set; } = null!;
        [ForeignKey(nameof(TransportationProviderId))]
        public IdentityUser TransportationProvider { get; set; } = null!;
        [Column(TypeName = "decimal(18,4)")]
        public decimal Profit { get; set; }
        public IdentityUser User { get; set; } = null!;
    }
}
