using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldTravelTour2024.Attributes;
using WorldTravelTour2024.Controllers.Authorization;
using WorldTravelTour2024.Core.Contracts.Host;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Models.Agent;
using WorldTravelTour2024.Core.Models.Reservations;
using WorldTravelTour2024.Core.Models.Traveller;
using static WorldTravelTour2024.Core.Constants.MessageConstants;

namespace WorldTravelTour2024.Controllers
{
    public class TravellerController : AuthorizationController
    {
        private readonly ITravellerService travellerService;
        private readonly IHostService hostService;

        public TravellerController(ITravellerService _travellerService,
            IHostService _hostService)
        {
            travellerService = _travellerService;
            hostService = _hostService;
        }
        [HttpGet]
        public async Task<IActionResult> UpdateInformation(BecomeTravellerFormModel model
            , string newLastName
            , string newPhoneNumber)
        {
            if(await travellerService.ExistByIdAsync(model.Id) == null)
            {
                return BadRequest();
            }

            model.LastName = newLastName;
            model.PhoneNumber = newPhoneNumber;
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateInformation()
        {
            var model = new BecomeTravellerFormModel();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeclineReservation(int hostId, int travellerId)
        {
            var host = await hostService.ExistAsync(hostId);
            var traveller = await travellerService.ExistByIdAsync(travellerId);
            if (host == null && traveller == null)
            {
                return Unauthorized();
            }
            if (await travellerService.DeclineResrevation(travellerId) == false)
            {
                return BadRequest();
            }
            var model = new DeclinedReservationFormModel()
            {
                TravellerId = traveller.Id,
                HostId = host.Id,
                Address = host.Address,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeclineReservation(DeclinedReservationFormModel model, int hostId, int travellerId)
        {
            var host = await hostService.ExistAsync(hostId);
            var traveller = await travellerService.ExistByIdAsync(travellerId);

            if (traveller == null || host == null)
            {
                return Unauthorized();
            }
            if (model == null)
            {
                return BadRequest();
            }

            await travellerService.DeclineResrevation(travellerId);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MakeReservation()
        {
            var model = new ReservationCreatedFormModel();

            return View(model);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> MakeReservation(ReservationCreatedFormModel model
            , int hostId
            , int travellerId
            , int numberOfTravellers
            , int numberOfNights)
        {
            var host = await hostService.ExistAsync(hostId);
            var traveller = await travellerService.ExistByIdAsync(travellerId);
            if (host != null && traveller != null)
            {
                model = new ReservationCreatedFormModel()
                {
                    TravellerId = traveller.Id,
                    HostId = host.Id,
                    Address = host.Address,
                    NumberOfRooms = host.Rooms,
                    NumberOfTravellers = numberOfTravellers,
                    NumberOfNigths = numberOfNights,
                };
            }
            await travellerService.MakeReservation(traveller.Id, host.Id, numberOfNights, numberOfTravellers);

            return View(model);
        }
        [HttpGet("{id}")]
        [NotTraveller]
        public async Task<IActionResult> BecomeTraveller()
        {
            if (await travellerService.GetTrvellerUserIdAsync(User.Id()) == true)
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
            if (await travellerService.GetTrvellerUserIdAsync(User.Id()) == true)
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

            return RedirectToAction(nameof(TravellerController.Index));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTraveller()
        {
             return RedirectToAction(nameof(HomeController));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTraveller(int travellerId)
        {
            var traveller = travellerService.ExistByIdAsync(travellerId);
            if (traveller == null)
            {
                return BadRequest();
            }

            await travellerService.DeleteByIdAsync(travellerId);
            return RedirectToAction(nameof(HomeController));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

