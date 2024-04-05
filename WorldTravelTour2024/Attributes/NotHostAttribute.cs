using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WorldTravelTour2024.Core.Contracts.Agent;
using WorldTravelTour2024.Core.Contracts.Host;
using System.Security.Claims;

namespace WorldTravelTour2024.Attributes
{
    public class NotHostAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            IHostService? hostService = context.HttpContext.RequestServices.GetService<IHostService>();

            if (hostService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (hostService != null && hostService.ExistAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }

    }
}
