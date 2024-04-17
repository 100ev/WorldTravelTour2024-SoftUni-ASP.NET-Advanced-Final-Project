using Microsoft.AspNetCore.Mvc;
using WorldTravelTour2024.Core.Contracts.Continent;
using WorldTravelTour2024.Core.Contracts.Host;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Models.Agent;
using WorldTravelTour2024.Core.Models.Destinations;

namespace WorldTravelTour2024.Controllers
{
    public class ContinentController : Controller
    {
        private readonly IContinentService continentService;
        private readonly ITravellerService travellerService;

        public ContinentController(IContinentService _continentService
            , ITravellerService _travellerService)
        {
            continentService = _continentService;
            travellerService = _travellerService;
        }

        public async Task<IActionResult> ContainsCountry(CountryIsInContinentFormModel model,int continentId, string country)
        {
            var continent = await continentService.ExistAsync(continentId);
            if(await continentService.ContainsCountryAsync(continentId, country) == false)
            {
                return BadRequest();
            }
            
            model.Country = country;
            model.Continent = continent.Name;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CanBeVisitedDuringThisSeasonByTraveller(ContinetIsVisitableFormModel model
            , int continentId
            , int travellerId
            , string season
            , string country)
        {
            var traveller = travellerService.ExistByIdAsync(travellerId);
            var continent = continentService.ExistAsync(continentId);
            

            if(continent == null || traveller == null)
            {
                return BadRequest();
            }

            if(await continentService.ChangeItsVisitablePropertyBasedOnSeasonAsync(continentId, season) == true)
            {
                model.ContinentId = continentId;
                model.TravellerId = travellerId;
                model.Season = season;
            }
            
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
