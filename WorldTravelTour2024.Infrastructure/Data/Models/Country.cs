using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorldTravelTour2024.Infrastructure.Data.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
