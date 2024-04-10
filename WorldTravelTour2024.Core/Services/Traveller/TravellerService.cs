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

        public async Task<bool> DeclineResrevation(int travellerId)
        {
            var traveller = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
                 .FirstOrDefaultAsync(t => t.Id == travellerId);
                if(traveller != null)
            {
                return true;
            }
            return false;
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

        public async Task<BecomeTravellerFormModel> ExistByIdAsync(int userId)
        {
           return await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
                .Where(t => t.Id == userId)
                .Select(t => new BecomeTravellerFormModel()
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,                   
                    Age = t.Age,
                    PhoneNumber = t.PhoneNumber,
                    Money = t.Money,
                })
                .FirstAsync();           
            
        }

        public async Task<bool> GetTrvellerUserIdAsync(string userId)
        {
             var traveller =  repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
                .FirstOrDefaultAsync(a => a.User.Id == userId);  
            
            if(traveller == null)
            {
                return false;
            }
            return true;
        }

        public Task<bool> IsAuthorisedToTravelAsync()
        {
            throw new NotImplementedException();
        }

        public async Task MakeReservation(int travellerId, int hostId, int numberOfNights, int numberOfTravellers)
        {
            var host = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Host>()
                .FirstOrDefaultAsync(h => h.Id == hostId);
            var traveller = await repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
                .FirstOrDefaultAsync(t => t.Id == travellerId);
            if (traveller != null && host != null)
            {
                if (numberOfTravellers < 3)
                {
                    host.Wallet += numberOfNights * numberOfTravellers;
                    traveller.Money -= numberOfNights * numberOfTravellers;
                }
            }
            await repository.SaveChangesAsync();
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
