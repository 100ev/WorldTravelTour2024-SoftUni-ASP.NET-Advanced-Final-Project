using Microsoft.EntityFrameworkCore;
using WorldTravelTour2024.Core.Contracts.CountryInformationAdvisor;
using WorldTravelTour2024.Core.Models.CountryInformationAdvisor;
using WorldTravelTour2024.Infrastructure.Common;

namespace WorldTravelTour2024.Core.Services.CountryInformationAdvisor
{
    public class CountryInformationAdvisorService : ICountryInformationAdvisorService
    {
        private readonly IUniversalRepository _repository;

        public CountryInformationAdvisorService(IUniversalRepository repository)
        {
            _repository = repository;
        }

        public async Task<CountryInformationFormModel> AssistTransportationProviderAsync(int transportationProviderId,int continentId, string country)
        {
            var transportationProvider = await _repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.TransportationProvider>()
                .FirstOrDefaultAsync(tp => tp.Id == transportationProviderId);

            var continent = await _repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Continent>()
                .FirstOrDefaultAsync(c => c.Id == continentId);

            if (transportationProvider != null && continent != null)
            {
                if (continent.Countries.FirstOrDefault(x => x.Name == country) != null)
                {
                    foreach (var item in continent.Countries)
                    {
                        if (item.Name == country)
                        {
                            var model = new CountryInformationFormModel()
                            {
                                Id = 1,
                                UserToAssist = $"{transportationProvider.FirstName} {transportationProvider.LastName}",
                                Country = item.Name,
                                Description = item.Description
                            };

                            return model;
                        }
                    }
                }
            }

            return null;
        }

        public async Task<CountryInformationFormModel> AssistTravellerAsync(int travellerID,int continentId, string country)
        {
            var traveller = await _repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Traveller>()
                .FirstOrDefaultAsync(t => t.Id == travellerID);

            var continent = await _repository.AllReadOnly<WorldTravelTour2024.Infrastructure.Data.Models.Continent>()
                .FirstOrDefaultAsync(c => c.Id == continentId);

            if (traveller != null && continent != null)
            {
                if (continent.Countries.FirstOrDefault(x => x.Name == country) != null)
                {
                    foreach (var item in continent.Countries)
                    {
                        if (item.Name == country)
                        {
                            var model = new CountryInformationFormModel()
                            {
                                Id = 1,
                                UserToAssist = $"{traveller.FirstName} {traveller.LastName}",
                                Country = item.Name,
                                Description = item.Description
                            };

                            return model;
                        }
                    }
                }
            }

            return null;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return id == 1;
        }
    }
}
