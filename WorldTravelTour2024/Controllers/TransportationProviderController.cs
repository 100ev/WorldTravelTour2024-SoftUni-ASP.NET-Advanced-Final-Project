using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldTravelTour2024.Attributes;
using WorldTravelTour2024.Controllers.Authorization;
using WorldTravelTour2024.Core.Contracts.TransportationProvider;
using WorldTravelTour2024.Core.Models.Host;
using WorldTravelTour2024.Core.Models.TransportationProvider;
using static WorldTravelTour2024.Core.Constants.MessageConstants;

namespace WorldTravelTour2024.Controllers
{
    public class TransportationProviderController : AuthorizationController
    {
        private readonly ITransportationProviderService _transportationProviderService;
        public TransportationProviderController(ITransportationProviderService transportationProviderService)
        {
            _transportationProviderService = transportationProviderService;
        }
        [HttpGet]
        [NotTransportationProvider]
        public async Task<IActionResult> BecomeTransportationProvider()
        {
            if (await _transportationProviderService.ExistAsync(User.Id()))
            {
                return BadRequest();
            }

            var model = new BecomeTransportationProvider();
            return View(model);
        }
        [HttpGet("{id}")]
        [NotTransportationProvider]
        public async Task<IActionResult> BecomeTransportationProvider(BecomeTransportationProvider model)
        {
            if (await _transportationProviderService.ExistAsync(User.Id()))
            {
                ModelState.AddModelError(nameof(model), UserAlreadyExistsMessage);            }


            await _transportationProviderService.RegisterTransportationProviderAsync(User.Id(), model.FirstName, model.LastName, model.PhoneNumber);
            return RedirectToAction(nameof(TransportationProviderController.Index));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
