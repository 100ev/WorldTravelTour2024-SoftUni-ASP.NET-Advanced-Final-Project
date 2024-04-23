using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorldTravelTour2024.Core.Models.Reservations
{
    public class TravellerLeftEarlyFormModel
    {
        [Display(Name = "Id of host")]
        public int HostId { get; set; }
        [Display(Name = "Number of travellers that left")]
        public int TravellersLeft { get; set; }
        [Display(Name = "The profit of the host")]
        public decimal HostProfit { get; set; }
    }
}
