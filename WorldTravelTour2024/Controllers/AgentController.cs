using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldTravelTour2024.Attributes;
using WorldTravelTour2024.Controllers.Authorization;
using WorldTravelTour2024.Core.Contracts.Agent;
using WorldTravelTour2024.Core.Models.Agent;
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
