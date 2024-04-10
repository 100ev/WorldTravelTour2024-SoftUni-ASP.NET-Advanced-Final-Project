using WorldTravelTour2024.Core.Models.Agent;
using WorldTravelTour2024.Core.Models.Traveller;

namespace WorldTravelTour2024.Core.Contracts.Traveller
{
    public interface ITravellerService
    {
        public Task<BecomeTravellerFormModel> ExistByIdAsync(int userId);
        public Task DeleteByIdAsync(int id);
        public Task<bool> GetTrvellerUserIdAsync(string userId);
        public Task RegisterAsync(string travellerId, string firstName, string lastName, string phoneNumber, int age);
        public Task<bool> IsAuthorisedToTravelAsync();       

        public Task UpdateInformationAsync(string id,string lastName, string phoneNumber);
        public Task MakeReservation(int travellerId,int hostId, int numberOfNights, int numberOfGuests);
        public Task<bool> DeclineResrevation(int travellerId);
    }
}
