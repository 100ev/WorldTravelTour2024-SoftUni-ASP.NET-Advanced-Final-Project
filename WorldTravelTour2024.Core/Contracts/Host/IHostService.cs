using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Core.Contracts.Host
{
    public interface IHostService
    {
        public Task<bool> ExistAsync(string userId);

        public Task UpdateAddressAsync(string id,string newAddress);

        public Task UpdatePersonalInformationAsync(string id,string phoneNumber, string email, int rooms);
        public Task RegisterHostAsync(string userId, string firstName, string lastName, string phoneNumber);

        public Task<bool> NumberOfRoomsExeedAllowedRooms(int rooms);

        public Task<bool> CanWellcomeTravellerAsync(string hostId,string travellerId);

        public Task RemoveAsync(string  id);
        public Task ReceiveProfitAsync();
    }
}
