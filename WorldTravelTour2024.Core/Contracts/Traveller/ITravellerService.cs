namespace WorldTravelTour2024.Core.Contracts.Traveller
{
    public interface ITravellerService
    {
        public Task<bool> ExistByIdAsync(string userId);

        public Task DeleteByIdAsync(int id);

        public Task RegisterAsync(string travellerId, string firstName, string lastName, string phoneNumber, int age);
        public Task<bool> IsAuthorisedToTravelAsync();       

        public Task UpdateInformationAsync(string id,string lastName, string phoneNumber);
    }
}
