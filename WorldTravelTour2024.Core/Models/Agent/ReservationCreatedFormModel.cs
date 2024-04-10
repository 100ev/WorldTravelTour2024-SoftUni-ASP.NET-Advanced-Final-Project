using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Core.Models.Agent
{
    public class ReservationCreatedFormModel
    {
        public int HostId { get; set; }
        public int TravellerId { get; set; }
        public string Address { get; set; } = string.Empty;
        public int NumberOfTravellers { get; set; }
        public int NumberOfNigths { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
