using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Core.Models.Agent
{
    public class BecomeAgentFormModel
    {
        public string FirstName { get; set; } = null!;        
        public string LastName { get; set; } = null!;        
        public string PhoneNumber { get; set; } = null!;        
        public string Email { get; set; } = null!;
    }
}
