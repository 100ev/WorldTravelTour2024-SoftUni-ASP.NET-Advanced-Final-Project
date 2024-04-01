using WorldTravelTour2024.Core.Contracts.Traveller;
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
    }
}
