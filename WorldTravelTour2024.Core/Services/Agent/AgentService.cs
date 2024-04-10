using Microsoft.EntityFrameworkCore;
using WorldTravelTour2024.Core.Contracts.Agent;
using WorldTravelTour2024.Core.Models.Host;
using WorldTravelTour2024.Core.Models.TransportationProvider;
using WorldTravelTour2024.Core.Models.Traveller;
using WorldTravelTour2024.Infrastructure.Common;
namespace WorldTravelTour2024.Core.Services.Agent
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public  async Task AskTransportFromTransportationProviderAsync(int travellerId, int trnasportationProviderId, string countryToTransportGuest)
        {
            var traveller = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
                .FirstOrDefaultAsync(t => t.Id == travellerId);
            var transportationProvider = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .FirstOrDefaultAsync(tp => tp.Id == trnasportationProviderId);

            if(traveller != null && transportationProvider != null)
            {
               if(transportationProvider.CountryNameToTransportGuest == countryToTransportGuest)
                {
                    transportationProvider.Profit += 250;
                }
            }

            await repository.SaveChangesAsync();
        }
        public async Task<bool> DeclineReservationAsync(int hostId)
        {
            var host = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(h => h.Host.Id == hostId);

            if(host != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .AnyAsync(a => a.User.Id == userId);
        }

        public async Task TravellerDecidedToLeaveEarlyAsync(int hostId, int numGuestsLeft)
        {
            var agentWithHost = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(h => h.Host.Id == hostId);
            if(agentWithHost != null)
            {
                if(agentWithHost.Host.Travellers.Count < numGuestsLeft)
                {
                    var sumToRemove = agentWithHost.Host.PricePerNight * numGuestsLeft;
                    agentWithHost.Host.Wallet -= sumToRemove;
                }
            }

            await repository.SaveChangesAsync();
        }

        public async Task<BecomeHostFormModel> HostExistByIdAsync(int hostId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .Where(h => h.Host.Id == hostId)
                .Select(h => new BecomeHostFormModel()
                {
                    Id = h.Host.Id,
                    FirstName = h.Host.FirstName,
                    LastName = h.Host.LastName,
                    PhoneNumber = h.Host.PhoneNumber,
                    Address = h.Host.Address,
                    PricePerNight = h.Host.PricePerNight,
                    Email = h.Host.Email,
                    Rooms = h.Host.Rooms,
                    Wallet = h.Host.Wallet,
                }).FirstAsync(); 
        }

        public async Task ReceiveBonusDuringSeasonAsync(int agentId, decimal bonus, string season)
        {
            var agent = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.Id == agentId);
            if (agent != null)
            {
                if (season == "Summer" || season == "Winter")
                {
                    agent.Profit += bonus;
                }
            }

            await repository.SaveChangesAsync();
        }

        public async Task ReceiveProfitAsync(int agentId, decimal profit)
        {
            var agent = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.Id == agentId);

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

        public async Task RemoveHostAsync(int HostId)
        {
            var hostToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.Host.Id == HostId);

            if (hostToRemove != null)
            {
                await repository
                    .RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.Agent>(hostToRemove.User.Id);
            }
            await repository.SaveChangesAsync();
        }

        public async Task RemoveTransportationProviderAsync(int transportationProviderId)
        {
            var transportationProviderToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.TransportationProvider.Id == transportationProviderId);

            if (transportationProviderToRemove != null)
            {
                await repository
                    .RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.Agent>(transportationProviderToRemove.User.Id);
            }
            await repository.SaveChangesAsync();
        }

        public async Task RemoveTravellerAsync(int travellerId)
        {
            var travellerToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.Traveller.Id == travellerId);

            if (travellerToRemove != null)
            {
                await repository
                    .RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.Agent>(travellerToRemove.User.Id);
            }
            await repository.SaveChangesAsync();
        }

        public async Task<BecomeTransportationProviderFormModel> TransportationProviderExistByIdAsync(int transportationProviderId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .Where(tp => tp.TransportationProvider.Id == transportationProviderId)
                .Select(tp => new BecomeTransportationProviderFormModel()
                {
                    Id = tp.TransportationProvider.Id,
                    FirstName = tp.TransportationProvider.FirstName,
                    LastName = tp.TransportationProvider.LastName,
                    PhoneNumber = tp.PhoneNumber,
                }).FirstAsync();
        }

        public async Task<BecomeTravellerFormModel> TravellerExistByIdAsync(int travellerId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .Where(t => t.Traveller.Id == travellerId).
                Select(t => new BecomeTravellerFormModel()
                {
                    Id = t.Traveller.Id,
                    FirstName = t.Traveller.FirstName,
                    LastName = t.Traveller.LastName,
                    PhoneNumber = t.Traveller.PhoneNumber,
                    Age = t.Traveller.Age,
                    Money = t.Traveller.Money
                }).FirstAsync(); 
        }

        public async Task UpdateHostAsync(int hostUserId, string phoneNumber, string email, int rooms)
        {
            var hostToUpdate = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.Host.Id == hostUserId);

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

        public async Task UpdateTransportationProviderAsync(int transportationProviderUserId, string phoneNumber)
        {
            var transportationProviderToUpdate = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.TransportationProvider.Id == transportationProviderUserId);

            if (transportationProviderUserId != null)
            {
                transportationProviderToUpdate.TransportationProvider.PhoneNumber = phoneNumber;
            }

            await repository.SaveChangesAsync();
        }

        public async Task UpdateTravellerAsync(int travelelrUSerId, string lastName, string phoneNumber)
        {
            var travellerToUpdate = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.Traveller.Id == travelelrUSerId);

            if (travellerToUpdate != null)
            {
                travellerToUpdate.Traveller.LastName = lastName;
                travellerToUpdate.Traveller.PhoneNumber = phoneNumber;
            }

            await repository.SaveChangesAsync();
        }
    }
}
