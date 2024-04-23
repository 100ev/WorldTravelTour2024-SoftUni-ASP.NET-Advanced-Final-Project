using System.ComponentModel.DataAnnotations;

namespace WorldTravelTour2024.Core.Models.Reservations
{
    public class DeclinedReservationFormModel
    {
        [Display(Name = "Id of traveller")]
        public int TravellerId { get; set; }
        [Display(Name = "Id of host")]
        public int HostId { get; set; }
        [Display(Name = "Address of the reservaton")]
        public string Address { get; set; } = string.Empty;
        [Display(Name = "The amount of refund that the traveller receives")]
        public decimal TravellerRefund { get; set; }
        [Display(Name = "The profit of the host")]
        public decimal HostProfit { get; set; }
    }
}
