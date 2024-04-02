using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NuGet.Packaging.Signing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Core.Contracts.Agent;
using WorldTravelTour2024.Infrastructure.Common;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Core.Services.Agent
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .AnyAsync(a => a.User.Id == userId);
        }

        public async Task<bool> HostExistByIdAsync(string hostId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
                .AnyAsync(h => h.User.Id == hostId);
        }

        public async Task ReceiveBonusDuringSeasonAsync(string agentId, decimal bonus, string season)
        {
            var agent = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.User.Id == agentId);
            if (agent != null)
            {
                if (season == "Summer" || season == "Winter")
                {
                    agent.Profit += bonus;
                }
            }

            await repository.SaveChangesAsync();
        }

        public async Task ReceiveProfitAsync(string agentId, decimal profit)
        {
            var agent = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.User.Id == agentId);

            if (agent != null)
            {
                agent.Profit += profit;
            }

            await repository.SaveChangesAsync();
        }

        public async Task RegisterAgentAsync(string userId, string firstName, string lastName, string phoneNumber, string email)
        {
            var agent = new WorldTravelTour2024.Infrastructure.Data.Models.Agent()
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = email
            };

            await repository.AddAsync<WorldTravelTour2024.Infrastructure.Data.Models.Agent>(agent);
            await repository.SaveChangesAsync();
        }

        public async Task RemoveHostAsync(string HostId)
        {
            var hostToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.Host.User.Id == HostId);

            if (hostToRemove != null)
            {
                await repository
                    .RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.Agent>(hostToRemove.User.Id);
            }
            await repository.SaveChangesAsync();
        }

        public async Task RemoveTransportationProviderAsync(string transportationProviderId)
        {
            var transportationProviderToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.TransportationProvider.User.Id == transportationProviderId);

            if (transportationProviderToRemove != null)
            {
                await repository
                    .RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.Agent>(transportationProviderToRemove.User.Id);
            }
            await repository.SaveChangesAsync();
        }

        public async Task RemoveTravellerAsync(string travellerId)
        {
            var travellerToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.Traveller.User.Id == travellerId);

            if (travellerToRemove != null)
            {
                await repository
                    .RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.Agent>(travellerToRemove.User.Id);
            }
            await repository.SaveChangesAsync();
        }

        public async Task<bool> TransportationProviderExistByIdAsync(string transportationProviderId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .AnyAsync(tp => tp.User.Id == transportationProviderId);
        }

        public async Task<bool> TravellerExistByIdAsync(string travellerId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
                .AnyAsync(t => t.User.Id == travellerId);
        }

        public async Task UpdateHostAsync(string hostUserId, string phoneNumber, string email, int rooms)
        {
            var hostToUpdate = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.Host.User.Id == hostUserId);

            if (hostToUpdate != null)
            {
                hostToUpdate.Host.PhoneNumber = phoneNumber;
                hostToUpdate.Host.Email = email;
                if (rooms > 3)
                {
                    hostToUpdate = null;
                }
                else
                {
                    hostToUpdate.Host.Rooms = rooms;
                }
            }
            await repository.SaveChangesAsync();
        }

        public async Task UpdateTransportationProviderAsync(string transportationProviderUserId, string phoneNumber)
        {
            var transportationProviderToUpdate = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.TransportationProvider.User.Id == transportationProviderUserId);

            if (transportationProviderUserId != null)
            {
                transportationProviderToUpdate.TransportationProvider.PhoneNumber = phoneNumber;
            }

            await repository.SaveChangesAsync();
        }

        public async Task UpdateTravellerAsync(string travelelrUSerId, string lastName, string phoneNumber)
        {
            var travellerToUpdate = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.Traveller.User.Id == travelelrUSerId);

            if (travellerToUpdate != null)
            {
                travellerToUpdate.Traveller.LastName = lastName;
                travellerToUpdate.Traveller.PhoneNumber = phoneNumber;
            }

            await repository.SaveChangesAsync();
        }
    }
}
