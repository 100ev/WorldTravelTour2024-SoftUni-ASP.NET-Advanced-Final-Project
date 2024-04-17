using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldTravelTour2024.Attributes;
using WorldTravelTour2024.Controllers.Authorization;
using WorldTravelTour2024.Core.Contracts.TransportationProvider;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Models.Destinations;
using WorldTravelTour2024.Core.Models.TransportationProvider;
using static WorldTravelTour2024.Core.Constants.MessageConstants;

namespace WorldTravelTour2024.Controllers
{
    public class TransportationProviderController : AuthorizationController
    {
        private readonly ITransportationProviderService _transportationProviderService;
        private readonly ITravellerService _travellerService;
        public TransportationProviderController(ITransportationProviderService transportationProviderService
            , ITravellerService travellerService)
        {
            _transportationProviderService = transportationProviderService;
            _travellerService = travellerService;
        }
        [HttpGet]
        public async Task<IActionResult> RemoveTransportationProvider(int transportationProviderId)
        {
            var transportationProvider = await _transportationProviderService.ExistAsync(transportationProviderId);
            if (transportationProvider == null)
            {
                return BadRequest();
            }

            await _transportationProviderService.RemoveAsync(transportationProvider.Id);

            return RedirectToAction(nameof(HomeController), "Home");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateInformation(int transportationProviderId, string newPhonenumber)
        {
            var transportationProvider = await _transportationProviderService.ExistAsync(transportationProviderId);
            if(transportationProvider == null)
            {
                return BadRequest();
            }

            await _transportationProviderService.UpdatePersonalInformationAsync(transportationProviderId, newPhonenumber);
            var model = new BecomeTransportationProviderFormModel()
            {
                PhoneNumber = newPhonenumber
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CanTransportTravelelrToDestination()
        {
            var model = new TransportationPossibleFormModel();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> CanTransportTravelelrToDestination(int transporationProviderId
            , int travellerId
            , string country,
            int numTravellers)
        {
            var transportationProvider = await _transportationProviderService.ExistAsync(transporationProviderId);
            var travellerToTransport = await _travellerService.ExistByIdAsync(travellerId);

            if (transportationProvider == null)
            {
                return BadRequest();
            }
            if (travellerToTransport == null)
            {
                return BadRequest();
            }
            if (await _transportationProviderService.CanTransportTravellerToCountryAsync(country) == false
                && _transportationProviderService.DeclineService(transportationProvider.Id, travellerToTransport.Id) == null
                && await _transportationProviderService.NumberOfTravellersAllowedToTransportAsync(transportationProvider.Id, numTravellers) == false)
            {
                return BadRequest();
            }

            var model = new TransportationPossibleFormModel()
            {
                TravellerId = travellerToTransport.Id,
                TransportationProviderId = transportationProvider.Id,
                Destination = country
            };

            return View(model);
        }
        [HttpGet]
        [NotTransportationProvider]
        public async Task<IActionResult> BecomeTransportationProvider()
        {
            if (await _transportationProviderService.GetTransportationProviderUserIdAsync(User.Id()) == true)
            {
                return BadRequest();
            }

            var model = new BecomeTransportationProviderFormModel();
            return View(model);
        }
        [HttpPost]
        [NotTransportationProvider]
        public async Task<IActionResult> BecomeTransportationProvider(BecomeTransportationProviderFormModel model)
        {
            if (await _transportationProviderService.GetTransportationProviderUserIdAsync(User.Id()) == true)
            {
                ModelState.AddModelError(nameof(model), UserAlreadyExistsMessage);
            }

            await _transportationProviderService.RegisterTransportationProviderAsync(User.Id(), model.FirstName, model.LastName, model.PhoneNumber);
            return RedirectToAction(nameof(TransportationProviderController.Index));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
