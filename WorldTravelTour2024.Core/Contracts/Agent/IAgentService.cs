using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Core.Models.Host;
using WorldTravelTour2024.Core.Models.TransportationProvider;
using WorldTravelTour2024.Core.Models.Traveller;

namespace WorldTravelTour2024.Core.Contracts.Agent
{
    public interface IAgentService
    {
        public Task RegisterAgentAsync(string userId, string firstName, string lastName, string phoneNumber, string email);
        public Task<bool> ExistByIdAsync(string agentId);
        public Task<BecomeTravellerFormModel> TravellerExistByIdAsync(int travellerId);
        public Task<BecomeHostFormModel> HostExistByIdAsync(int hostId);
        public Task<BecomeTransportationProviderFormModel> TransportationProviderExistByIdAsync(int transportationProviderId);
        public Task RemoveTravellerAsync(int travellerId);
        public Task RemoveHostAsync(int HostId);
        public Task RemoveTransportationProviderAsync(int transportationProviderId);
        public Task UpdateTravellerAsync(int travelelrUSerId,string lastName, string phoneNumber);
        public Task UpdateHostAsync(int hostUserId,string phoneNumber, string email, int rooms);
        public Task UpdateTransportationProviderAsync(int transportationProviderUserId, string phoneNumber);
        public Task ReceiveProfitAsync(int agentId,decimal profid);
        public Task AskTransportFromTransportationProviderAsync(int travellerId, int trnasportationProviderId, string countryToTransportGuest);
        public Task ReceiveBonusDuringSeasonAsync(int agentId,decimal profit, string season);
        public Task<bool> DeclineReservationAsync(int hostId);
        public Task TravellerDecidedToLeaveEarlyAsync(int hostId, int numGuestsLeft);
    }
}
