using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WorldTravelTour2024.Core.Contracts.Agent;
using WorldTravelTour2024.Core.Contracts.Traveller;
using System.Security.Claims;

namespace WorldTravelTour2024.Attributes
{
    public class NotTravellerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            ITravellerService? travellerService = context.HttpContext.RequestServices.GetService<ITravellerService>();

            if (travellerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (travellerService != null && travellerService.ExistByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }

    }
}
