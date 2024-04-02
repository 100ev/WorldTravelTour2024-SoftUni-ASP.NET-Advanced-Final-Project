using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Core.Contracts.TransportationProvider;
using WorldTravelTour2024.Core.Models.TransportationProvider;
using WorldTravelTour2024.Infrastructure.Common;
using WorldTravelTour2024.Infrastructure.Data.Models;

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

        public async Task<bool> ExistAsync(string userId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .AnyAsync(tp => tp.User.Id == userId);
        }

        public async Task NumberOfTravellersAllowedToTransportAsync(int numTravellers)
        {
            throw new NotImplementedException();
        }
        public async Task<decimal> ReceiveProfitAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RegisterTransportationProviderAsync(string userId, string firstName, string lastName, string phoneNumber)
        {
            var transportationProvider = new BecomeTransportationProvider()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };
            await repository.AddAsync<WorldTravelTour2024.Core.Models.TransportationProvider.BecomeTransportationProvider>
                (transportationProvider);
            await repository.SaveChangesAsync();
        }

        public async Task RemoveAsync(string id)
        {
            var transportationProviderToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .FirstOrDefaultAsync(tp => tp.User.Id == id);

            if (transportationProviderToRemove != null)
            {
                await repository.RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>(id);
            }
            await repository.SaveChangesAsync();
        }

        public async Task UpdatePersonalInformationAsync(string userId,string phoneNumber)
        {
            var transportationProvider = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .FirstOrDefaultAsync(tp => tp.User.Id == userId);

            if (transportationProvider != null)
            {
                transportationProvider.PhoneNumber = phoneNumber;
            }
            await repository.SaveChangesAsync();
                
        }
    }
}
