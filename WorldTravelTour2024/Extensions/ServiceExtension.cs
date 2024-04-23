using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldTravelTour2024.Core.Contracts.Agent;
using WorldTravelTour2024.Core.Contracts.Continent;
using WorldTravelTour2024.Core.Contracts.CountryInformationAdvisor;
using WorldTravelTour2024.Core.Contracts.Host;
using WorldTravelTour2024.Core.Contracts.TransportationProvider;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Services.Agent;
using WorldTravelTour2024.Core.Services.Continent;
using WorldTravelTour2024.Core.Services.Host;
using WorldTravelTour2024.Core.Services.TransportationProvider;
using WorldTravelTour2024.Core.Services.Traveller;
using WorldTravelTour2024.Infrastructure.Common;
using WorldTravelTour2024.Infrastructure.Data;

namespace WorldTravelTour2024.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<ITravellerService, TravellerService>();
            service.AddScoped<IHostService, HostService>();
            service.AddScoped<ITransportationProviderService, TransportationProviderService>();
            service.AddScoped<IAgentService, AgentService>();
            service.AddScoped<IContinentService, ContinentService>();
            service.AddScoped<ICountryInformationAdvisorService, ICountryInformationAdvisorService>();

            return service;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<WorldTravelTour2024DbContext>(options => 
                options.UseSqlServer(connectionString));

            services.AddScoped<IUniversalRepository, UniversalRepository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<WorldTravelTour2024DbContext>();

            return services;
        }
    }
}
