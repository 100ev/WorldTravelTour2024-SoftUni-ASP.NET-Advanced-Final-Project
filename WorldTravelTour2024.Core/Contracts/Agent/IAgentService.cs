using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Core.Contracts.Agent
{
    public interface IAgentService
    {
        public Task RegisterAgentAsync(string userId, string firstName, string lastName, string phoneNumber, string email);
        public Task<bool> ExistByIdAsync(string agentId);
        public Task<bool> TravellerExistByIdAsync(string travellerId);
        public Task<bool> HostExistByIdAsync(string hostId);
        public Task<bool> TransportationProviderExistByIdAsync(string transportationProviderId);
        public Task RemoveTravellerAsync(string travellerId);
        public Task RemoveHostAsync(string HostId);
        public Task RemoveTransportationProviderAsync(string transportationProviderId);
        public Task UpdateTravellerAsync(string travelelrUSerId,string lastName, string phoneNumber);
        public Task UpdateHostAsync(string hostUserId,string phoneNumber, string email, int rooms);
        public Task UpdateTransportationProviderAsync(string transportationProviderUserId, string phoneNumber);
        public Task ReceiveProfitAsync(string agentId,decimal profid);
        public Task ReceiveBonusDuringSeasonAsync(string agentId,decimal profit, string season);
    }
}
