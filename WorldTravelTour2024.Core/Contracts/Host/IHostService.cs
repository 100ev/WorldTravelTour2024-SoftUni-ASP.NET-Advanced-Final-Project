using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Core.Models.Host;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Core.Contracts.Host
{
    public interface IHostService
    {
        public Task<BecomeHostFormModel> ExistAsync(int userId);
        public Task<bool> GetHostUserIdAsync(string userId);
        public Task UpdateAddressAsync(int id,string newAddress);
        public Task UpdatePersonalInformationAsync(int id,string phoneNumber, string email, int rooms);
        public Task RegisterHostAsync(string userId, string firstName, string lastName, string phoneNumber, int rooms);

        public Task<bool> NumberOfRoomsExeedAllowedRooms(int rooms);

        public Task<bool> CanWellcomeTravellerAsync(int hostId,int travellerId);

        public Task RemoveAsync(int id);
        public Task ReceiveProfitAsync();
    }
}
