using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Core.Models.Traveller;
using WorldTravelTour2024.Core.Services.Traveller;

namespace WorldTravelTour2024.Core.Models.Host
{
    public class BecomeHostFormModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;        
        public string LastName { get; set; } = null!;        
        public string Email { get; set; } = null!;
        public  decimal PricePerNight { get; set; }
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public List<BecomeTravellerFormModel> Travellers { get; set; } = new List<BecomeTravellerFormModel>();
        public int Rooms { get; set; }
        public decimal Wallet { get; set; }
    }
}
