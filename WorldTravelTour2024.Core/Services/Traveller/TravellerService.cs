using Microsoft.EntityFrameworkCore;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Models.Traveller;
using WorldTravelTour2024.Infrastructure.Common;

namespace WorldTravelTour2024.Core.Services.Traveller
{
    public class TravellerService : ITravellerService
    {
        private readonly IRepository repository;

        public TravellerService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var travellerToRemove = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
               .FirstOrDefaultAsync(tp => tp.Id == id);

            if (travellerToRemove != null)
            {
                await repository.RemoveAsync<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>(id);
            }
            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
                .AnyAsync(t => t.User.Id == userId);
        }

        public Task<bool> IsAuthorisedToTravelAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(string travellerId, string firstName, string lastName, string phoneNumber, int age)
        {
            var traveller = new WorldTravelTour2024.Infrastructure.Data.Models.Traveller()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Age = age,
                UserId = travellerId

            };
            if (traveller.Age > 18)
            {
                await repository.AddAsync<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>(traveller);
            }
            await repository.SaveChangesAsync();
        }

        public async Task UpdateInformationAsync(string id,string lastName, string phoneNumber)
        {
            var travellerToUpdate = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
                .FirstOrDefaultAsync(t => t.UserId == id);
            if (travellerToUpdate != null)
            {
                travellerToUpdate.LastName = lastName;
                travellerToUpdate.PhoneNumber = phoneNumber;
            }
            await repository.SaveChangesAsync();
        }
    }
}
