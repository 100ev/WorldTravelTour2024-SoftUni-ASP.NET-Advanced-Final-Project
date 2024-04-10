using Microsoft.EntityFrameworkCore;
using WorldTravelTour2024.Core.Contracts.TransportationProvider;
using WorldTravelTour2024.Core.Models.TransportationProvider;
using WorldTravelTour2024.Infrastructure.Common;

namespace WorldTravelTour2024.Core.Services.TransportationProvider
{
    public class TransportationProviderService : ITransportationProviderService
    {
        private readonly IRepository repository;

        public TransportationProviderService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> CanTransportTravellerToCountryAsync(string country)
        {
            if (await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .AnyAsync(tp => tp.CountryNameToTransportGuest == country))
            {
                return true;
            }

            return false;
        }

        public async Task DeclineService(int transportationProviderId,int travellerID)
        {
            var transportationProvider = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
               .FirstOrDefaultAsync(tp => tp.Id == transportationProviderId);
            var traveller = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
               .FirstOrDefaultAsync(t => t.Id == travellerID);

        }

        public async Task<BecomeTransportationProviderFormModel> ExistAsync(int userId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .Where(tp => tp.Id == userId)
                .Select(tp => new BecomeTransportationProviderFormModel()
                {
                    FirstName = tp.FirstName,
                    LastName = tp.LastName,
                    PhoneNumber = tp.PhoneNumber
                })
                .FirstAsync();
        }

        public async Task<bool> GetTransportationProviderUserIdAsync(string userId)
        {
            var transportationProvider =  repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .FirstOrDefaultAsync(a => a.User.Id == userId);

            if(transportationProvider == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> NumberOfTravellersAllowedToTransportAsync(int transportationproviderId, int numTravellers)
        {
            var transportatioProvider = await repository.AllReadOnly< WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                    .FirstOrDefaultAsync(tp => tp.Id == transportationproviderId);
            if (transportatioProvider != null)
            {
                if (numTravellers > 5)
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<decimal> ReceiveProfitAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RegisterTransportationProviderAsync(string userId, string firstName, string lastName, string phoneNumber)
        {
            var transportationProvider = new BecomeTransportationProviderFormModel()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };
            await repository.AddAsync<WorldTravelTour2024.Core.Models.TransportationProvider.BecomeTransportationProviderFormModel>
                (transportationProvider);
            await repository.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var transportationProviderToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .FirstOrDefaultAsync(tp => tp.Id == id);

            if (transportationProviderToRemove != null)
            {
                await repository.RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>(id);
            }
            await repository.SaveChangesAsync();
        }

        public async Task UpdatePersonalInformationAsync(int userId, string phoneNumber)
        {
            var transportationProvider = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .FirstOrDefaultAsync(tp => tp.Id == userId);

            if (transportationProvider != null)
            {
                transportationProvider.PhoneNumber = phoneNumber;
            }
            await repository.SaveChangesAsync();

        }
    }
}
