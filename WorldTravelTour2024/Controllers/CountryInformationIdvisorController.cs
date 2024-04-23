using Microsoft.AspNetCore.Mvc;
using WorldTravelTour2024.Core.Contracts.Continent;
using WorldTravelTour2024.Core.Contracts.CountryInformationAdvisor;
using WorldTravelTour2024.Core.Contracts.TransportationProvider;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Models.Continent;
using WorldTravelTour2024.Core.Models.CountryInformationAdvisor;
using WorldTravelTour2024.Core.Models.TransportationProvider;
using WorldTravelTour2024.Core.Models.Traveller;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Controllers
{
    public class CountryInformationIdvisorController : Controller
    {
        private readonly ICountryInformationAdvisorService _countryInformationAdvisorService;
        private readonly ITravellerService _travellerService;
        private readonly ITransportationProviderService _transportationProviderService;
        private readonly IContinentService _continentService;

        public CountryInformationIdvisorController(ICountryInformationAdvisorService countryInformationAdvisorService
            , ITravellerService travellerService
            , ITransportationProviderService transportationProviderService
            , IContinentService continentService)
        {
            _countryInformationAdvisorService = countryInformationAdvisorService;
            _travellerService = travellerService;
            _transportationProviderService = transportationProviderService;
            _continentService = continentService;
        }
        [HttpGet]
        public async Task<IActionResult> AssistransportationProvider(CountryInformationFormModel model)
        {
            model = new CountryInformationFormModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssistTransportationProvider(CountryInformationFormModel model,
            int transportationProviderId,
            int continentId,
            string country)
        {
            BecomeTransportationProviderFormModel transportationProvider = await _transportationProviderService.ExistAsync(transportationProviderId);
            ContinentFormModel continent = await _continentService.ExistAsync(continentId);

            if (transportationProvider != null && continent != null)
            {
                foreach (var item in continent.Countries)
                {
                    if (item.Name == country)
                    {
                        {
                            model.Id = 1;
                            model.UserToAssist = $"{transportationProvider.FirstName} {transportationProvider.LastName}";
                            model.Country = item.Name;
                            model.Description = item.Description;
                        };

                    }
                }
                await _countryInformationAdvisorService.AssistTravellerAsync(transportationProviderId, continentId, country);
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AssistTraveller(CountryInformationFormModel model)
        {
            model = new CountryInformationFormModel();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssistTraveller(
            CountryInformationFormModel model,
            int travellerID, 
            int continentId, 
            string country)
        {
            BecomeTravellerFormModel traveller =await _travellerService.ExistByIdAsync(travellerID);
            ContinentFormModel continent =await _continentService.ExistAsync(continentId);

            if (traveller != null && continent != null)
            {
                foreach (var item in continent.Countries)
                {
                    if (item.Name == country)
                    {                        
                        {
                            model.Id = 1;
                            model.UserToAssist = $"{traveller.FirstName} {traveller.LastName}";
                            model.Country = item.Name;
                            model.Description = item.Description;
                        };

                    }
                }
                await _countryInformationAdvisorService.AssistTravellerAsync(travellerID, continentId, country);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Exist(int id)
        {
            var countryInformationAdvisor = _countryInformationAdvisorService.ExistAsync(id);
            if (countryInformationAdvisor != null)
            {
                return Ok(countryInformationAdvisor);
            }
            return BadRequest();
        } 
        public IActionResult Index()
        {
            return View();
        }
    }
}
