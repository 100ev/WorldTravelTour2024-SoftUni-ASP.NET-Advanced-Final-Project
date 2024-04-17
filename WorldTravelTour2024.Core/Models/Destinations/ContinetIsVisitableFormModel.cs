using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Core.Models.Destinations
{
    public class ContinetIsVisitableFormModel
    {
        public int ContinentId { get; set; }
        public int TravellerId { get; set; }
        public string Season { get; set; } = string.Empty;
    }
}
