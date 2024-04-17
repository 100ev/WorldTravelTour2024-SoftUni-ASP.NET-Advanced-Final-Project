using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldTravelTour2024.Attributes;
using WorldTravelTour2024.Controllers.Authorization;
using WorldTravelTour2024.Core.Contracts.Host;
using WorldTravelTour2024.Core.Models.Host;
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
        [HttpPost]
        public async Task<IActionResult> DeleteHost()
        {
            return RedirectToAction(nameof(HomeController));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteHost(int hostId)
        {
            var host = _hostService.ExistAsync(hostId);
            if (host == null)
            {
                return BadRequest();
            }

            await _hostService.RemoveAsync(hostId);
            return RedirectToAction(nameof(HomeController));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAddress()
        {
            var model = new BecomeHostFormModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAddress(BecomeHostFormModel model, int hostId, string newAddress)
        {
            var host = await _hostService.ExistAsync(hostId);
            if (host == null)
            {
                return Unauthorized();
            }
            if (model.Id == host.Id)
            {
                model.Address = newAddress;
            }
            await _hostService.UpdateAddressAsync(host.Id, newAddress);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateInformation(BecomeHostFormModel model, int hostId, string newPhonenumber, string newEmail, int newNumRooms)
        {
            var host = _hostService.ExistAsync(hostId);
            if (host == null)
            {
                return Unauthorized();
            }
            if (newNumRooms > 3)
            {
                return BadRequest();
            }
            if (model.Id == host.Id)
            {
                model.PhoneNumber = newPhonenumber;
                model.Email = newEmail;
                model.Rooms = newNumRooms;
            }
            await _hostService.UpdatePersonalInformationAsync(hostId, newPhonenumber, newEmail, newNumRooms);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateInformation(int hostId)
        {
            var model = new BecomeHostFormModel();

            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> CanWelcomeGuest(int hostId, int travellerId)
        {
            var isHostEligibletoWelcomeTraveller = await _hostService.CanWellcomeTravellerAsync(hostId, travellerId);

            if (isHostEligibletoWelcomeTraveller == false)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(HomeController));
        }
        [HttpGet]
        [NotHost]
        public async Task<IActionResult> BecomeHost()
        {
            if (await _hostService.GetHostUserIdAsync(User.Id()) == true)
            {
                return BadRequest();
            }

            var model = new BecomeHostFormModel();
            return View(model);
        }
        [HttpPost]
        [NotHost]
        public async Task<IActionResult> BecomeHost(BecomeHostFormModel model)
        {
            if (await _hostService.GetHostUserIdAsync(User.Id()) == true)
            {
                ModelState.AddModelError(nameof(model), UserAlreadyExistsMessage);
            }
            if (model.Rooms > 3)
            {
                ModelState.AddModelError(nameof(model.Rooms), HostRoomsExceedAllowedNumber);
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
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
