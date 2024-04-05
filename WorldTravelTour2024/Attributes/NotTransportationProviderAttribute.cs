using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WorldTravelTour2024.Core.Contracts.Agent;
using WorldTravelTour2024.Core.Contracts.TransportationProvider;
using System.Security.Claims;

namespace WorldTravelTour2024.Attributes
{
    public class NotTransportationProviderAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            ITransportationProviderService? transportationProviderService = context.HttpContext.RequestServices
                .GetService<ITransportationProviderService>();

            if (transportationProviderService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (transportationProviderService != null && transportationProviderService.ExistAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }

    }
}
