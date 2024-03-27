using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldTravelTour2024.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
