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
    [Comment("Traveller information")]
    public class Traveller
    {
        [Key]
        [Comment("Traveller Id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("Traveller First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("Traveller Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [Comment("Traveller Age")]
        public int Age { get; set; }
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Traveller Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        [Comment("Traveller Money that can be spent for vacation")]
        public decimal Money { get; set; }
        public IdentityUser User { get; set; } = null!;
    }
}
