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
    public class Host
    {

        [Key]
        [Comment("Host Id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("Host First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("Host Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(EmailMaxLength)]
        [Comment("Host Email")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("Host address")]
        public string Address { get; set; } = string.Empty;
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Host Phone Number")]        
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(MaxNumberOfHostRooms)]
        [Comment("The number of rooms that the host owns")]
        public int Rooms { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        [Comment("The Price for one night for a room")]
        public decimal PricePerNight { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        [Comment("The balance of the Host payout")]
        public decimal Wallet { get; set; }
        public IEnumerable<Traveller> Travellers { get; set; } = new List<Traveller>();
        public IdentityUser User { get; set; } = null!;
    }
}
