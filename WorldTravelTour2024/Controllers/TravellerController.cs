using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldTravelTour2024.Attributes;
using WorldTravelTour2024.Controllers.Authorization;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Models.Traveller;
using static WorldTravelTour2024.Core.Constants.MessageConstants;

namespace WorldTravelTour2024.Controllers
{
    public class TravellerController : AuthorizationController
    {
        private readonly ITravellerService travellerService;

        public TravellerController(ITravellerService _travellerService)
        {
            travellerService = _travellerService;
        }

        [HttpGet("{id}")]
        [NotTraveller]
        public async Task<IActionResult> BecomeTraveller()
        {
            if (await travellerService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }

            var model = new BecomeTravellerFormModel();
            return View(model);
        }

        [HttpPost]
        [NotTraveller]
        public async Task<IActionResult> BecomeTraveller(BecomeTravellerFormModel model)
        {
            if (await travellerService.ExistByIdAsync(User.Id()))
            {
                ModelState.AddModelError(nameof(model), UserAlreadyExistsMessage);
            }
            if (model.Age < 18)
            {
                ModelState.AddModelError(nameof(model.Age), TravellerMustBeAnAdult);
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await travellerService.RegisterAsync(User.Id(), model.FirstName, model.LastName, model.PhoneNumber, model.Age);

            return RedirectToAction(nameof(TravellerController));
        }
    }
}
