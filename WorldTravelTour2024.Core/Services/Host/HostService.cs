using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Core.Contracts.Host;
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
        public async Task<bool> CanWellcomeTravellerAsync(string hostId,string travellerId)
        {
            var host = await repository.ExistByIdAsync<WorldTravelTour2024.Infrastructure.Data.Models.Host>(hostId);

            if(host != null)
            {
                var travelelr = host.Travellers.Any(t => t.User.Id == travellerId);
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

        public async Task<bool> ExistAsync(string userId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
                 .AnyAsync(h => h.User.Id == userId);
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

        public async Task RegisterHostAsync(string userId, string firstName, string lastName, string phoneNumber)
        {
            var host = new WorldTravelTour2024.Infrastructure.Data.Models.Host()
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };
            await repository.AddAsync<WorldTravelTour2024.Infrastructure.Data.Models.Host>(host);
            await repository.SaveChangesAsync();
        }

        public async Task RemoveAsync(string id)
        {
            var hostToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
               .FirstOrDefaultAsync(tp => tp.User.Id == id);

            if (hostToRemove == null)
            {

            }
            await repository.RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.Host>(id);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAddressAsync(string userId ,string newAddress)
        {
            var host = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
                .FirstOrDefaultAsync(tp => tp.User.Id == userId);
            if (host == null)
            {

            }
            host.Address = newAddress;
            await repository.SaveChangesAsync();
        }

        public async Task UpdatePersonalInformationAsync(string userId, string phoneNumber, string email, int rooms)
        {
            var host = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
                .FirstOrDefaultAsync(tp => tp.User.Id == userId);

            if (host == null)
            {

            }
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
            await repository.SaveChangesAsync();
        }
    }
}
