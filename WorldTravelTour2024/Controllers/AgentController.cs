using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldTravelTour2024.Attributes;
using WorldTravelTour2024.Controllers.Authorization;
using WorldTravelTour2024.Core.Contracts.Agent;
using WorldTravelTour2024.Core.Models.Agent;
using WorldTravelTour2024.Core.Models.Host;
using WorldTravelTour2024.Core.Models.Reservations;
using WorldTravelTour2024.Core.Models.TransportationProvider;
using WorldTravelTour2024.Core.Models.Traveller;
using static WorldTravelTour2024.Core.Constants.MessageConstants;

namespace WorldTravelTour2024.Controllers
{
    public class AgentController : AuthorizationController
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }
        [HttpPost]
        public async Task<IActionResult> RemoveHost(int hostId)
        {
            var agentWithHost = await _agentService.HostExistByIdAsync(hostId);
            if(agentWithHost == null)
            {
                return BadRequest();
            }

            await _agentService.RemoveHostAsync(agentWithHost.Id);

            return RedirectToAction(nameof(AgentController));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveTraveller(int travellerId)
        {
            var agentWithTraveller = await _agentService.TravellerExistByIdAsync(travellerId);
            if (agentWithTraveller == null)
            {
                return BadRequest();
            }

            await _agentService.RemoveTravellerAsync(agentWithTraveller.Id);

            return RedirectToAction(nameof(AgentController));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveTransportationProvider(int transportationProviderId)
        {
            var agentWitTransportationProvider = await _agentService
                .TransportationProviderExistByIdAsync(transportationProviderId);
            if (agentWitTransportationProvider == null)
            {
                return BadRequest();
            }

            await _agentService.RemoveTransportationProviderAsync(agentWitTransportationProvider.Id);

            return RedirectToAction(nameof(AgentController));
        }
        [HttpPost]
        public async Task<IActionResult> TravellerLeftEarly()
        {
            var model =new TravellerLeftEarlyFormModel();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> TravellerLeftEarly(int hostId, int numOfTravellersThatLeft)
        {
            var host = await _agentService.HostExistByIdAsync(hostId);
            if(host == null)
            {
                return BadRequest();
            }

            await _agentService.TravellerDecidedToLeaveEarlyAsync(host.Id, numOfTravellersThatLeft);
            var model = new TravellerLeftEarlyFormModel()
            {
                HostId = host.Id,
                TravellersLeft = host.Travellers.Count,
                HostProfit = host.Wallet
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AskHelpFromTransportationProvider(int travellerId
            , int transportationProviderId
            , string country)
        {
            var traveller = await _agentService.TravellerExistByIdAsync(travellerId);
            var transportationProvider = await _agentService.TransportationProviderExistByIdAsync(transportationProviderId);

            if (traveller == null || transportationProvider == null)
            {
                return BadRequest();
            }
            if (transportationProvider.Countries.Any(c => c.Name != country))
            {
                return BadRequest();
            }
            await _agentService.AskTransportFromTransportationProviderAsync(traveller.Id, transportationProvider.Id, country);

            return RedirectToAction(nameof(AgentController.Index));

        }
        [HttpGet]
        public async Task<IActionResult> DeclineReservation(int hostId, int nights)
        {
            var host =await _agentService.HostExistByIdAsync(hostId);
            if(host == null)
            {
                return BadRequest();
            }

            decimal ammount = host.PricePerNight * nights;
            var model = new DeclinedReservationFormModel()
            {
                HostId = host.Id,
                Address = host.Address,
                TravellerRefund = ammount,
                HostProfit = host.Wallet - ammount
            };
            await _agentService.DeclineReservationAsync(hostId);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeclineReservation(int hostId)
        {
            var model = new DeclinedReservationFormModel()
            {
                HostId = hostId,
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> FindTraveller(BecomeTravellerFormModel model, int travellerId)
        {
            var traveller = await _agentService.TravellerExistByIdAsync(travellerId);
            if(traveller == null)
            {
                return BadRequest();
            }

            if(model.Id == traveller.Id)
            {
                return View(model);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FindTraveller(int id)
        {
            var model = new BecomeTravellerFormModel();
            if(model.Id == id)
            {
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> FindHost(BecomeHostFormModel model, int hostId)
        {
            var host = await _agentService.HostExistByIdAsync(hostId);
            if (host == null)
            {
                return BadRequest();
            }

            if (model.Id == host.Id)
            {
                return View(model);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FindHost(int id)
        {
            var model = new BecomeHostFormModel();
            if (model.Id == id)
            {
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> FindTransportationProvider(BecomeTransportationProviderFormModel model, int transportationProviderId)
        {
            var transportationProvider = await _agentService.TransportationProviderExistByIdAsync(transportationProviderId);
            if (transportationProvider == null)
            {
                return BadRequest();
            }

            if (model.Id == transportationProvider.Id)
            {
                return View(model);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FindTransportationProvider(int id)
        {
            var model = new BecomeTransportationProviderFormModel();
            if (model.Id == id)
            {
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTravellerInformation(BecomeTravellerFormModel model
            , int travellerId
            , string newLastName
            , string newPhoneNumber)
        {
            var traveller = _agentService.TravellerExistByIdAsync(travellerId);
            if (traveller == null)
            {
                return BadRequest();
            }
            await _agentService.UpdateTravellerAsync(travellerId, newLastName, newPhoneNumber);
            model.LastName = newLastName;
            model.PhoneNumber = newPhoneNumber;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTravellerInformation()
        {
            var model = new BecomeTravellerFormModel();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateHostInformation(BecomeHostFormModel model
            , int hostId
            , string newEmail
            , string newPhoneNumber
            , int newNumRooms)
        {
            var host = _agentService.HostExistByIdAsync(hostId);
            if (host == null)
            {
                return BadRequest();
            }
            await _agentService.UpdateHostAsync(hostId, newPhoneNumber, newEmail, newNumRooms);
            model.PhoneNumber = newPhoneNumber;
            model.Email = newEmail;
            model.Rooms = newNumRooms;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHostInformation()
        {
            var model = new BecomeHostFormModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTransportationproviderInformation(BecomeTransportationProviderFormModel model
            , int transportationProviderId
            , string newPhoneNumber)
        {
            var transportationProvider = _agentService.TransportationProviderExistByIdAsync(transportationProviderId);
            if (transportationProvider == null)
            {
                return BadRequest();
            }
            await _agentService.UpdateTransportationProviderAsync(transportationProviderId, newPhoneNumber);
            model.PhoneNumber = newPhoneNumber;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTransportationproviderInformation()
        {
            var model = new BecomeTransportationProviderFormModel();

            return View(model);
        }
        [HttpGet]
        [NotAgent]
        public async Task<IActionResult> BecomeAgent()
        {
            if (await _agentService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }

            var model = new BecomeAgentFormModel();
            return View(model);
        }
        [HttpPost]
        [NotAgent]
        public async Task<IActionResult> BecomeAgent(BecomeAgentFormModel model)
        {
            if (await _agentService.ExistByIdAsync(User.Id()))
            {
                ModelState.AddModelError(nameof(model), UserAlreadyExistsMessage);
            }
            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            await _agentService.RegisterAgentAsync(User.Id(), model.FirstName, model.LastName, model.PhoneNumber, model.Email);
            return RedirectToAction(nameof(AgentController));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
