using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Core.Models.Reservations
{
    public class DeclinedReservationFormModel
    {
        public int TravellerId { get; set; }
        public int HostId { get; set; }
        public string Address { get; set; }
        public decimal TravellerRefund { get; set; }
        public decimal HostProfit { get; set; }
    }
}
