using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Core.Models.CountryInformationAdvisor;

namespace WorldTravelTour2024.Core.Contracts.CountryInformationAdvisor
{
    public interface ICountryInformationAdvisorService
    {
        public Task<bool> ExistAsync(int id);
        public Task<CountryInformationFormModel> AssistTravellerAsync(int travellerID, int continentId, string country);
        public Task<CountryInformationFormModel> AssistTransportationProviderAsync(int transportationProviderId,int continentId, string country);

    }
}
