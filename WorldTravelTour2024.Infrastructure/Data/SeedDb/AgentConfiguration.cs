using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Infrastructure.Data.SeedDb
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(a => a.Host)
                .WithMany()
                .HasForeignKey(a => a.HostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.Traveller)
                .WithMany()
                .HasForeignKey(a => a.TravellerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.TransportationProvider)
                .WithMany()
                .HasForeignKey(a => a.TransportationProviderId)
                .OnDelete(DeleteBehavior.NoAction);
            
            var data = new SeedDatabase();
            builder.HasData(data.Agent);
        }
    }
}
