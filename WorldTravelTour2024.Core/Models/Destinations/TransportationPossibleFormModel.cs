using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Core.Models.Destinations
{
    public class TransportationPossibleFormModel
    {
        public int TravellerId { get; set; }
        public int TransportationProviderId { get; set; }
        public string Destination { get; set; } = string.Empty;
    }
}
