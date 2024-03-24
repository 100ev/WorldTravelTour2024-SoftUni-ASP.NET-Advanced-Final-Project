using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Infrastructure.Data.Models
{
    public class Continent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool IsVisitableDuringThisSeason { get; set; }
        public IEnumerable<Country> Countries { get; set; } = new List<Country>();
    }
}
