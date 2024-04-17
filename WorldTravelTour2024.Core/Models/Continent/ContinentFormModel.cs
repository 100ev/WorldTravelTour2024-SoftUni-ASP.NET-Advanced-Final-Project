using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Core.Models.Continent
{
    public class ContinentFormModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsVisitableDuringThisSeason { get; set; } = true;
        public IEnumerable<Country> Countries { get; set; } = new List<Country>();
    }
}
