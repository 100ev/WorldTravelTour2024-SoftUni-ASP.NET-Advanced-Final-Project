using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldTravelTour2024.Attributes;
using WorldTravelTour2024.Controllers.Authorization;
using WorldTravelTour2024.Core.Contracts.Host;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Models.Host;
using WorldTravelTour2024.Core.Models.Traveller;
using WorldTravelTour2024.Core.Services.Traveller;
using static WorldTravelTour2024.Core.Constants.MessageConstants;

namespace WorldTravelTour2024.Controllers
{
    public class HostController : AuthorizationController
    {
        private readonly IHostService _hostService;

        public HostController(IHostService hostService)
        {
            _hostService = hostService;
        }
        [HttpGet]
        [NotHost]
        public async Task<IActionResult> BecomeHost()
        {
            if (await _hostService.ExistAsync(User.Id()))
            {
                return BadRequest();
            }

            var model = new BecomeHostFormModel();
            return View(model);
        }
        [HttpGet("{id}")]
        [NotHost]
        public async Task<IActionResult> BecomeHost(BecomeHostFormModel model)
        {
            if(await _hostService.ExistAsync(User.Id()))
            {
                ModelState.AddModelError(nameof(model), UserAlreadyExistsMessage);
            }
            if(model.Rooms > 3)
            {
                ModelState.AddModelError(nameof(model.Rooms), HostRoomsExceedAllowedNumber);
            }

            await _hostService.RegisterHostAsync(User.Id(), model.FirstName, model.LastName, model.PhoneNumber, model.Rooms);
            return RedirectToAction(nameof(HostController.Index));
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
