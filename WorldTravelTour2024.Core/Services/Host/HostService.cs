using Microsoft.EntityFrameworkCore;
using WorldTravelTour2024.Core.Contracts.Host;
using WorldTravelTour2024.Core.Models.Host;
using WorldTravelTour2024.Infrastructure.Common;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Core.Services.Host
{
    public class HostService : IHostService
    {
        private readonly IRepository repository;

        public HostService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<bool> CanWellcomeTravellerAsync(int hostId, int travellerId)
        {
            var host = await repository.ExistByIdAsync<WorldTravelTour2024.Infrastructure.Data.Models.Host>(hostId);

            if (host != null)
            {
                var travelelr = host.Travellers.Any(t => t.Id == travellerId);
                if (travelelr == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            return false;
        }

        public async Task<BecomeHostFormModel> ExistAsync(int userId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
                .Where(h => h.Id == userId)
                .Select(h => new BecomeHostFormModel()
                {
                    Id = h.Id,
                    FirstName = h.FirstName,
                    LastName = h.LastName,
                    Address = h.Address,
                    PricePerNight = h.PricePerNight,
                    PhoneNumber = h.PhoneNumber,
                    Rooms = h.Rooms,
                    Wallet = h.Wallet
                })
                .FirstAsync();

        }

        public async Task<bool> GetHostUserIdAsync(string userId)
        {
            var host = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
                .FirstOrDefaultAsync(a => a.User.Id == userId);
            if(host == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> NumberOfRoomsExeedAllowedRooms(int rooms)
        {
            if (rooms > 3)
            {
                return false;
            }

            return true;
        }

        public async Task ReceiveProfitAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RegisterHostAsync(string userId, string firstName, string lastName, string phoneNumber, int rooms)
        {
            if (rooms <= 3)
            {
                var host = new WorldTravelTour2024.Infrastructure.Data.Models.Host()
                {
                    UserId = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber

                };
                await repository.AddAsync<WorldTravelTour2024.Infrastructure.Data.Models.Host>(host);
            }
        await repository.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var hostToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
           .FirstOrDefaultAsync(tp => tp.Id == id);

        if (hostToRemove != null)
        {
            await repository.RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.Host>(id);
        }
        await repository.SaveChangesAsync();
    }

    public async Task UpdateAddressAsync(int userId, string newAddress)
    {
        var host = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
            .FirstOrDefaultAsync(tp => tp.Id == userId);
        if (host != null)
        {
            host.Address = newAddress;
        }
        await repository.SaveChangesAsync();
    }

    public async Task UpdatePersonalInformationAsync(int userId, string phoneNumber, string email, int rooms)
    {
        var host = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
            .FirstOrDefaultAsync(tp => tp.Id == userId);

        if (host != null)
        {
            host.PhoneNumber = phoneNumber;
            host.Email = email;
            if (rooms > 3)
            {
                NumberOfRoomsExeedAllowedRooms(rooms);
            }
            else
            {
                host.Rooms = rooms;
            }
        }
        await repository.SaveChangesAsync();
    }
}
}
