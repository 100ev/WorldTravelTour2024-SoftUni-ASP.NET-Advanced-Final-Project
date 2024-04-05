using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorldTravelTour2024.Controllers.Authorization;
using WorldTravelTour2024.Core.Contracts.Agent;
using WorldTravelTour2024.Core.Contracts.Continent;
using WorldTravelTour2024.Core.Contracts.Host;
using WorldTravelTour2024.Core.Contracts.TransportationProvider;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Models.Home;
using WorldTravelTour2024.Models;

namespace WorldTravelTour2024.Controllers
{
    public class HomeController : AuthorizationController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITravellerService _travellerService;
        private readonly ITransportationProviderService _transportationProviderService;
        private readonly IHostService _hostService;
        private readonly IAgentService _agentService;
        private readonly IContinentService _continentService;


        public HomeController(ILogger<HomeController> logger,
            ITravellerService travellerService,
            ITransportationProviderService transportationProviderService,
            IHostService hostService,
            IAgentService agentService,
            IContinentService continentService)
        {
            _logger = logger;
            _travellerService = travellerService;
            _transportationProviderService = transportationProviderService;
            _hostService = hostService;
            _agentService = agentService;
            _continentService = continentService;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}