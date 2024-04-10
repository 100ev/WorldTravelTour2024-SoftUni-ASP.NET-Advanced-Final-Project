using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Core.Models.TransportationProvider;

namespace WorldTravelTour2024.Core.Contracts.TransportationProvider
{
    public interface ITransportationProviderService
    {
        public Task<BecomeTransportationProviderFormModel> ExistAsync(int userId);
        public Task<bool> GetTransportationProviderUserIdAsync(string userId);
        public Task UpdatePersonalInformationAsync(int userId,string phoneNumber);
        public Task<bool> CanTransportTravellerToCountryAsync(string country);
        public Task<bool> NumberOfTravellersAllowedToTransportAsync(int id,int numTravellers);
        public Task RegisterTransportationProviderAsync(string userId, string firstName, string lastName, string phoneNumber);
        public Task RemoveAsync(int id);
        public Task DeclineService(int transportationProviderId, int travellerId);
        public Task<decimal> ReceiveProfitAsync();
    }
}
