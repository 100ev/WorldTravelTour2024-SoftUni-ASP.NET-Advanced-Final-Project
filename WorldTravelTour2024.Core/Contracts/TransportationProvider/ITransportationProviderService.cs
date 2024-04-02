using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Core.Contracts.TransportationProvider
{
    public interface ITransportationProviderService
    {
        public Task<bool> ExistAsync(string userId);
        public Task UpdatePersonalInformationAsync(string userId,string phoneNumber);
        public Task<bool> CanTransportTravellerToCountryAsync(string country);
        public Task NumberOfTravellersAllowedToTransportAsync(int numTravellers);
        public Task RegisterTransportationProviderAsync(string userId, string firstName, string lastName, string phoneNumber);
        public Task RemoveAsync(string id);
        public Task<decimal> ReceiveProfitAsync();
    }
}
