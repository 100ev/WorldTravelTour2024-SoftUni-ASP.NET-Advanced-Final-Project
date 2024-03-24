using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorldTravelTour2024.Infrastructure.Data.SeedDb
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new SeedDatabase();

            builder.HasData(new IdentityUser[] 
            { 
                data.AgentUser, 
                data.HostUser, 
                data.TravellerUser,
                data.TransportationProviderUser
            });
        }
    }
}
