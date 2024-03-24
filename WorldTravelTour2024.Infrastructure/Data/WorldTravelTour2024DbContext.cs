using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorldTravelTour2024.Infrastructure.Data.Models;
using WorldTravelTour2024.Infrastructure.Data.SeedDb;

namespace WorldTravelTour2024.Infrastructure.Data
{
    public class WorldTravelTour2024DbContext : IdentityDbContext
    {
        public WorldTravelTour2024DbContext(DbContextOptions<WorldTravelTour2024DbContext> options)
            : base(options)
        {
        }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new HostConfiguration());
            builder.ApplyConfiguration(new TravellerConfiguration());
            builder.ApplyConfiguration(new TransportationProviderConfiguration());
            builder.ApplyConfiguration(new ContinentConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Traveller> Travellers { get; set; } = null!;
        public DbSet<Host> Hosts { get; set; } = null!;
        public DbSet<TransportationProvider> TransportationProviders { get; set; } = null!;
        public DbSet<Agent> Agents { get; set; } = null!;
        public DbSet<Continent> Continents { get; set; } = null!;
    }
}